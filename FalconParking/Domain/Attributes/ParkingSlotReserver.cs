using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class ParkingSlotReserver : ParkingSlotOcuppant
    {
        private ParkingSlotReservationTime reservationTime { get; set; }

        public ParkingSlotReserver(
            string CarLicensePlate,
            ParkingSlotReservationTime ReservationTime) : base(CarLicensePlate)
        {
            reservationTime = ReservationTime;
        }
    }
}
