using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalconParkingClient.Models
{
    public class FreeParkingSlotRequest
    {
        public Guid ParkingSlotId { get; set; }
        public Guid CurrentUserId { get; set; }
        public string CarLicensePlate { get; set; }

        public FreeParkingSlotRequest() { }

        public FreeParkingSlotRequest(
            Guid parkingSlotId
            ,Guid currentUserId
            ,string carLicensePlate)
        {
            ParkingSlotId = parkingSlotId;
            CurrentUserId = currentUserId;
            CarLicensePlate = carLicensePlate;
        }
    }
}
