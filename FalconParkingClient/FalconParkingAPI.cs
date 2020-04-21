using FalconParkingClient.Views;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FalconParkingClient
{
    public static class FalconParkingAPI
    {
        private static HttpClient client = new HttpClient();
        public const string Path = "https://localhost:44369";

        public delegate void UpdateLotsCallback(IEnumerable<ParkingLotView> ParkingLots);

        public static async Task<IEnumerable<ParkingLotView>> GetParkingLots()
        {
            IEnumerable<ParkingLotView> lotViews = null;
            HttpResponseMessage response = await client.GetAsync($"{Path}/parkingLots/");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                lotViews = JsonConvert.DeserializeObject<IEnumerable<ParkingLotView>>(content);
            }
            return lotViews;
        }

        public static async void ParkingLotDataUpdater(MainWindow window)
        {
            while (true)
            {
                window.Dispatcher.Invoke(
                    new UpdateLotsCallback(window.UpdateData),
                    await GetParkingLots()
                );
                Thread.Sleep(1500);
            }
        }
    }
}
