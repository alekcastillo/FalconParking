using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalconParkingAPI.Models
{
    public class OccupyParkingSlotRequest
    {
        public int AggregateId { get; set; }
        public int ParkingSlotId { get; set; }
        public string CarLicensePlate { get; set; }
        public string UserIdentification { get; set; }

        public OccupyParkingSlotRequest() { }

        public OccupyParkingSlotRequest(
            int aggregateId,
            int parkingSlotId,
            string carLicensePlate,
            string userIdentification)
        {
            AggregateId = aggregateId;
            ParkingSlotId = parkingSlotId;
            CarLicensePlate = carLicensePlate;
            UserIdentification = userIdentification;
        }
    }
}
