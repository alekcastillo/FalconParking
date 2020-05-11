using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalconParkingAPI.Models
{
    public class OccupyParkingSlotRequest
    {
        public Guid ParkingSlotId { get; set; }
        public Guid CurrentUserId { get; set; }
        public string CarLicensePlate { get; set; }
        public string UserIdentification { get; set; }

        public OccupyParkingSlotRequest() { }

        public OccupyParkingSlotRequest(
            Guid parkingSlotId
            ,Guid currentUserId
            ,string carLicensePlate
            ,string userIdentification)
        {
            ParkingSlotId = parkingSlotId;
            CurrentUserId = currentUserId;
            CarLicensePlate = carLicensePlate;
            UserIdentification = userIdentification;
        }
    }
}
