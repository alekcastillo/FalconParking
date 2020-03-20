using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Entities
{
    public class ParkingSlot
    {
        private int id { get; }
        private ParkingSlotOcuppant currentOcuppant { get; set; }
        private ParkingSlotStatus status { get; set; }
        private bool isAvailable() { return status == ParkingSlotStatus.AVAILABLE; }

        public ParkingSlot(
            int Id)
        {
            id = id;
            currentOcuppant = null;
            status = ParkingSlotStatus.AVAILABLE;
        }

        public void Ocuppy(string carLicensePlate)
        {
            var newOcuppant = new ParkingSlotOcuppant(carLicensePlate);
            currentOcuppant = newOcuppant;
            status = ParkingSlotStatus.OCCUPPIED;
        }

        public void Reserve(string carLicensePlate)
        {
            var newOcuppant = new ParkingSlotOcuppant(carLicensePlate);
            currentOcuppant = newOcuppant;
            status = ParkingSlotStatus.OCCUPPIED;
        }

        public void Free()
        {
            currentOcuppant = null;
            status = ParkingSlotStatus.AVAILABLE;
        }

        public void Open()
        {
            currentOcuppant = null;
            status = ParkingSlotStatus.AVAILABLE;
        }

        public void Close()
        {
            currentOcuppant = null;
            status = ParkingSlotStatus.CLOSED;
        }
    }
}
