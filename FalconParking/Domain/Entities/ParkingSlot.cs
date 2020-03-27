using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Entities
{
    public class ParkingSlot
    {
        public int Id { get; }
        public ParkingSlotOcuppant CurrentOcuppant { get; private set; }
        public ParkingSlotStatus Status { get; private set; }
        public bool isAvailable() { return Status == ParkingSlotStatus.Available; }

        public ParkingSlot(
            int id)
        {
            Id = id;
            CurrentOcuppant = null;
            Status = ParkingSlotStatus.Available;
        }

        public void Ocuppy(string carLicensePlate)
        {
            var newOcuppant = new ParkingSlotOcuppant(carLicensePlate);
            CurrentOcuppant = newOcuppant;
            Status = ParkingSlotStatus.Occuppied;
        }

        public void Reserve(string carLicensePlate, ParkingSlotReservationTime reservationTime)
        {
            var newOcuppant = new ParkingSlotReserver(carLicensePlate, reservationTime);
            CurrentOcuppant = newOcuppant;
            Status = ParkingSlotStatus.Reserved;
        }

        public void Free()
        {
            CurrentOcuppant = null;
            Status = ParkingSlotStatus.Available;
        }

        public void Open()
        {
            CurrentOcuppant = null;
            Status = ParkingSlotStatus.Available;
        }

        public void Close()
        {
            CurrentOcuppant = null;
            Status = ParkingSlotStatus.Closed;
        }
    }
}
