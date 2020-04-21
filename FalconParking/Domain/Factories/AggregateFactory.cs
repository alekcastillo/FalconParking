using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Factories
{
    public static class AggregateFactory
    {
        public static ParkingLot CreateParkingLot(
            Guid aggregateId)
        {
            return new ParkingLot(aggregateId);
        }

        public static ParkingSlot CreateParkingSlot(
            Guid aggregateId)
        {
            return new ParkingSlot(aggregateId);
        }
    }
}
