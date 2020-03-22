using AutoMapper;
using FalconParking.Infrastructure.Commands;
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
