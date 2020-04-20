using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalconParkingAPI.Models
{
    public class AddParkingLotRequest
    {
        public string Code { get; set; }
        public int TotalSlotsCount { get; set; }
        //public int[] ReservableSlots { get; set; }

        public AddParkingLotRequest() { }

        public AddParkingLotRequest(
            string code
            ,int totalSlotsCount
            //,int[] reservableSlots
            )
        {
            Code = code;
            TotalSlotsCount = totalSlotsCount;
            //ReservableSlots = reservableSlots;
        }
    }
}
