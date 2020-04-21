using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace FalconParkingClient
{
    public class TCPClient
    {
        private const int portNum = 13;
        private const string hostName = "localhost";

        public static Guid TryLogin(string email, string password)
        {
            Guid result = Guid.Empty;
            string loginInfo = $"{email};{password}";

            try
            {
                Console.WriteLine("Connecting...");
                var client = new TcpClient(hostName, portNum);

                Console.WriteLine("Connection accepted.");
                NetworkStream ns = client.GetStream();

                byte[] byteTime = Encoding.ASCII.GetBytes(loginInfo);
                ns.Write(byteTime, 0, byteTime.Length);

                byte[] bytes = new byte[1024];
                int bytesRead = ns.Read(bytes, 0, bytes.Length);

                result = new Guid(Encoding.ASCII.GetString(bytes, 0, bytesRead));

                client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return result;
        }
    }
}
