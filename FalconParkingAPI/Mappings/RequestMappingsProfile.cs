﻿using AutoMapper;
using FalconParking.Application.Commands;
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

            //Slot Requests
            CreateMap<OccupyParkingSlotRequest, OccupyParkingSlotCommand>();
        }
    }
}
