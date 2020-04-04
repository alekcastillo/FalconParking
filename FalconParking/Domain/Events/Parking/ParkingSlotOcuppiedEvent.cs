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
            ,string carLicensePlate) : base(parkingLotId, parkingSlotId)
        {
            CarLicensePlate = carLicensePlate;
        }

        //This MUST be changed
        public override string ToString()
        {
            return "{" +
                $"\"ParkingSlotId\" : {ParkingSlotId}" +
                $"\"CarLicensePlate\" : {CarLicensePlate}" +
                //$"\"UserIdentification\" : {UserIdentification}" +
                "}";
        }
    }
}
