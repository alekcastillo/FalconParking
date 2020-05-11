using Application.Abstractions.Commands;
using System;

namespace Application.Commands
{
    public class AddParkingLotCommand : ICommand<Guid>
    {
        public string Code { get; set; }
        public int TotalSlotsCount { get; set; }
        //public int[] ReservableSlots { get; set; }

        public AddParkingLotCommand() { }

        public AddParkingLotCommand(
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
