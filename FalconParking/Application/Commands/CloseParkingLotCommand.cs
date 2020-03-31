using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Commands
{
    public class CloseParkingLot : DomainCommand
    {
        public int ParkingSlotId { get; }
        public string UserIdentification { get; }

        public CloseParkingLot(
            int aggregateId,
            int parkingSlotId,
            string userIdentification) : base(aggregateId)
        {
            ParkingSlotId = parkingSlotId;
            UserIdentification = userIdentification;
        }
    }
}
