using FalconParkingClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParkingClient
{
    public static class FalconParkingAPI
    {
        private static HttpClient client = new HttpClient();
        public const string Path = "https://localhost:44369";

        public delegate void UpdateLotsCallback(IEnumerable<ParkingLotView> ParkingLots);


        /// <summary>
        /// Devuelve el response del servidor de la vista de todos los parqueos
        /// con sus respectivos campos
        /// </summary>
        public static async Task<IEnumerable<ParkingLotView>> GetParkingLots()
        {
            IEnumerable<ParkingLotView> lotViews = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    $"{Path}/parkingLots/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    lotViews = JsonConvert.DeserializeObject<IEnumerable<ParkingLotView>>(content);
                }
            }
            catch (Exception ex)
            {
                //Do nothing
            }

            return lotViews;
        }

        /// <summary>
        /// Llama al endpoint para ocupar campos del servidor
        /// y devuelve un booleano dependiendo de si fue exitoso
        /// </summary>
        public static async Task<bool> OccupyParkingSlot(
            Guid parkingSlotId
            ,string licensePlate
            ,string userIdentification)
        {
            try
            {
                var request = new OccupyParkingSlotRequest(
                    parkingSlotId
                    ,UserRoles.CurrentUserId
                    ,licensePlate
                    ,userIdentification);
                var json = JsonConvert.SerializeObject(request, Formatting.Indented);
                var httpContent = new StringContent(json);
                httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                HttpResponseMessage response = await client.PostAsync(
                    $"{Path}/parkingSlots/occupy"
                    ,httpContent);
                response.EnsureSuccessStatusCode();

                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Llama al endpoint para desocupar campos del servidor
        /// y devuelve un booleano dependiendo de si fue exitoso
        /// </summary>
        public static async Task<bool> FreeParkingSlot(
            Guid parkingSlotId
            ,string licensePlate)
        {
            try
            {
                var request = new FreeParkingSlotRequest(
                    parkingSlotId
                    ,UserRoles.CurrentUserId
                    ,licensePlate);
                var json = JsonConvert.SerializeObject(request, Formatting.Indented);
                var httpContent = new StringContent(json);
                httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                HttpResponseMessage response = await client.PostAsync(
                    $"{Path}/parkingSlots/free"
                    , httpContent);
                response.EnsureSuccessStatusCode();

                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }

        public static async Task<bool> ReserveParkingSlot(
            Guid parkingSlotId
            ,int reservationTime)
        {
            try
            {
                var request = new ReserveParkingSlotRequest(
                    parkingSlotId
                    ,UserRoles.CurrentUserId
                    ,reservationTime);
                var json = JsonConvert.SerializeObject(request, Formatting.Indented);
                var httpContent = new StringContent(json);
                httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                HttpResponseMessage response = await client.PostAsync(
                    $"{Path}/parkingSlots/reserve"
                    , httpContent);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza la data de los parqueos cada 2 segundos para evitar
        /// descoordinacion con el servidor
        /// </summary>
        public static async void ParkingLotDataUpdater(MainWindow window)
        {
            try
            {
                while (true)
                {
                    window.Dispatcher.Invoke(
                        new UpdateLotsCallback(window.UpdateData),
                        await GetParkingLots()
                    );
                    Thread.Sleep(20000);
                }
            }
            catch (Exception ex)
            {
                ParkingLotDataUpdater(window);
            }
        }
    }
}
