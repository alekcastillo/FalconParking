using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Commands
{
    public class FreeParkingSlotCommand : DomainCommand
    {
        public int ParkingSlotId { get; }
        public string CarLicensePlate { get; }
        public string UserIdentification { get; }

        public FreeParkingSlotCommand(
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
