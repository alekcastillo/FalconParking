using AutoMapper;
using Application.Commands;
using FalconParkingAPI.Models;

namespace FalconParkingAPI.Mappings
{
    public class RequestMappingsProfile : Profile
    {
        public RequestMappingsProfile()
        {
            //Lot Requests
            CreateMap<AddParkingLotRequest, AddParkingLotCommand>();
            CreateMap<OpenParkingLotRequest, OpenParkingLotCommand>();
            CreateMap<CloseParkingLotRequest, CloseParkingLotCommand>();

            //Slot Requests
            CreateMap<OccupyParkingSlotRequest, OccupyParkingSlotCommand>();
            CreateMap<FreeParkingSlotRequest, FreeParkingSlotCommand>();
            CreateMap<ReserveParkingSlotRequest, ReserveParkingSlotCommand>();
        }
    }
}
