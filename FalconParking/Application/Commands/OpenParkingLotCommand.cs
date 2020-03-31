using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Commands
{
    public class OpenParkingLot : DomainCommand
    {
        public int ParkingSlotId { get; }
        public string UserIdentification { get; }

        public OpenParkingLot(
            int aggregateId,
            int parkingSlotId,
            string userIdentification) : base(aggregateId)
        {
            ParkingSlotId = parkingSlotId;
            UserIdentification = userIdentification;
        }
    }
}
