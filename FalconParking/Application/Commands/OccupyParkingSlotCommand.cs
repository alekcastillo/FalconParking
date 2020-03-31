using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Commands
{
    public class OccupyParkingSlotCommand : DomainCommand
    {
        public int ParkingSlotId { get; }
        public string CarLicensePlate { get; }
        public string UserIdentification { get; }

        public OccupyParkingSlotCommand(
            int aggregateId,
            int parkingSlotId,
            string carLicensePlate,
            string userIdentification) : base(aggregateId)
        {
            ParkingSlotId = parkingSlotId;
            CarLicensePlate = carLicensePlate;
            UserIdentification = userIdentification;
        }
    }
}
