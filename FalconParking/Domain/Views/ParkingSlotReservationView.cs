using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Views
{
    public class ParkingSlotReservationView
    {
        public int ParkingSlotId { get; set; }
        public int MinutesReserved { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
        public int DeletedBy { get; set; }
    }
}
