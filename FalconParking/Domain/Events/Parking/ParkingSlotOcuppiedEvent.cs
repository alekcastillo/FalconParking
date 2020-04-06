using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotOcuppiedEvent : ParkingSlotEvent
    {
        public string CarLicensePlate { get; }

        public ParkingSlotOcuppiedEvent(
            int parkingLotId
            ,int parkingSlotId
            ,int userId
            ,string carLicensePlate
         ) : base(
            parkingLotId
            ,parkingSlotId
            ,userId)
        {
            CarLicensePlate = carLicensePlate;
        }
    }
}
