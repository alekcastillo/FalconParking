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
            ,int userId
            ,int parkingSlotId
            ,string carLicensePlate
         ) : base(
            parkingLotId
            ,userId
            ,parkingSlotId)
        {
            CarLicensePlate = carLicensePlate;
        }
    }
}
