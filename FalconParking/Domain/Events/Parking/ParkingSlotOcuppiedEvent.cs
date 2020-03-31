﻿using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotOcuppiedEvent : ParkingSlotEvent
    {
        public string CarLicensePlate { get; }
        public string UserIdentification { get; }

        public ParkingSlotOcuppiedEvent(
            int parkingLotId
            ,int parkingSlotId
            ,string carLicensePlate
            ,string userIdentification) : base(parkingLotId, parkingSlotId)
        {
            CarLicensePlate = carLicensePlate;
            UserIdentification = userIdentification;
        }

        //This MUST be changed
        public override string ToString()
        {
            return "{" +
                $"\"ParkingSlotId\" : {ParkingSlotId}" +
                $"\"CarLicensePlate\" : {CarLicensePlate}" +
                $"\"UserIdentification\" : {UserIdentification}" +
                "}";
        }
    }
}
