using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FalconParking.Infrastructure.Tasks
{
    public static class LoginSocketThread
    {
        private const int portNum = 13;

        public static void Start()
        {
            bool done = false;
            var listener = new TcpListener(IPAddress.Any, portNum);

            listener.Start();

            while (!done)
            {
                try
                {
                    Console.Write("Waiting for connection...");
                    var client = listener.AcceptTcpClient();

                    Console.WriteLine("Connection accepted.");
                    NetworkStream ns = client.GetStream();

                    byte[] bytes = new byte[1024];
                    int bytesRead = ns.Read(bytes, 0, bytes.Length);

                    Console.WriteLine("Trying login...");
                    string loginInfo = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    string[] loginInfoArray = loginInfo.Split(';');
                    string result = TryLogin(loginInfoArray[0], loginInfoArray[1]).ToString();

                    byte[] byteTime = Encoding.ASCII.GetBytes(result);
                    ns.Write(byteTime, 0, byteTime.Length);

                    ns.Close();
                    client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            listener.Stop();
        }

        private static Guid TryLogin(string email, string password)
        {
            if (email == PlaceHolderAccounts.Admin.Email
                && password == PlaceHolderAccounts.Admin.Password)
                return PlaceHolderAccounts.Admin.Id;

            if (email == PlaceHolderAccounts.Client.Email
                && password == PlaceHolderAccounts.Client.Password)
                return PlaceHolderAccounts.Client.Id;

            return Guid.Empty;
        }
    }
}
