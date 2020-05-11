using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalconParkingAPI.Models
{
    public class ReserveParkingSlotRequest
    {
        public Guid ParkingSlotId { get; set; }
        public Guid CurrentUserId { get; set; }
        public int ReservationTime { get; set; }

        public ReserveParkingSlotRequest() { }

        public ReserveParkingSlotRequest(
            Guid parkingSlotId
            ,Guid currentUserId
            ,int reservationTime)
        {
            ParkingSlotId = parkingSlotId;
            CurrentUserId = currentUserId;
            ReservationTime = reservationTime;
        }
    }
}
