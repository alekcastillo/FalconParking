using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalconParkingAPI.Models
{
    public class OpenParkingLotRequest
    {
        public Guid ParkingLotId { get; set; }
        public Guid CurrentUserId { get; set; }

        public OpenParkingLotRequest() { }

        public OpenParkingLotRequest(
            Guid parkingLotId
            ,Guid currentUserId)
        {
            ParkingLotId = parkingLotId;
            CurrentUserId = currentUserId;
        }
    }
}
