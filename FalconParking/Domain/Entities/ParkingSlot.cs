using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Entities
{
    public class ParkingSlot
    {
        public int id { get; }
        public ParkingSlotOcuppant currentOcuppant { get; private set; }
        public ParkingSlotStatus status { get; private set; }
        public bool isAvailable() { return status == ParkingSlotStatus.Available; }

        public ParkingSlot(
            int Id)
        {
            id = id;
            currentOcuppant = null;
            status = ParkingSlotStatus.Available;
        }

        public void Ocuppy(string carLicensePlate)
        {
            var newOcuppant = new ParkingSlotOcuppant(carLicensePlate);
            currentOcuppant = newOcuppant;
            status = ParkingSlotStatus.Occuppied;
        }

        public void Reserve(string carLicensePlate, ParkingSlotReservationTime reservationTime)
        {
            var newOcuppant = new ParkingSlotReserver(carLicensePlate, reservationTime);
            currentOcuppant = newOcuppant;
            status = ParkingSlotStatus.Reserved;
        }

        public void Free()
        {
            currentOcuppant = null;
            status = ParkingSlotStatus.Available;
        }

        public void Open()
        {
            currentOcuppant = null;
            status = ParkingSlotStatus.Available;
        }

        public void Close()
        {
            currentOcuppant = null;
            status = ParkingSlotStatus.Closed;
        }
    }
}
