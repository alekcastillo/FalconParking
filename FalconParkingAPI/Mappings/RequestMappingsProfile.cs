using AutoMapper;
using FalconParking.Application.Commands;
using FalconParkingAPI.Models;

namespace FalconParkingAPI.Mappings
{
    public class RequestMappingsProfile : Profile
    {
        public RequestMappingsProfile()
        {
            CreateMap<OccupyParkingSlotRequest, OccupyParkingSlotCommand>();
        }
    }
}
