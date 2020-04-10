using FalconParking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Factories
{
    public static class ParkingLotFactory
    {
        public static ParkingLot CreateParkingLot(int id)
        {
            switch(id)
            {
                case 1:
                    return CreateParkingLotA();
                case 2:
                    return CreateParkingLotB();
                case 3:
                    return CreateParkingLotC();
                default:
                    throw new DomainException($"No existe un parqueo {id}");
            }
        }

        private static ParkingLot CreateParkingLotA()
        {
            return ParkingLot.New(
                aggregateId : 0
                , code : "A"
                , x : 0.0f
                , y : 0.0f
                , totalSlotsCount : 30);
        }

        private static ParkingLot CreateParkingLotB()
        {
            return ParkingLot.New(
                aggregateId: 1
                , code: "B"
                , x: 0.0f
                , y: 0.0f
                , totalSlotsCount: 20);
        }

        private static ParkingLot CreateParkingLotC()
        {
            return ParkingLot.New(
                aggregateId: 0
                , code: "C"
                , x: 0.0f
                , y: 0.0f
                , totalSlotsCount: 10);
        }
    }
}
