using AutoMapper;
using FalconParking.Domain.Interfaces;
using FalconParking.Infrastructure.Queries;
using FalconParking.Views;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Infrastructure.Handlers
{
    public class GetLotInformationHandler : IRequestHandler<GetLotInformationQuery, ParkingClientView>
    {
        private readonly IParkingEventRepository _eventsRepository;
        //private readonly IMapper _mapper;

        public GetLotInformationHandler(
            IParkingEventRepository eventsRepository)
            //IMapper mapper)
        {
            _eventsRepository = eventsRepository;
           // _mapper = mapper;
        }

        public async Task<ParkingClientView> Handle(GetLotInformationQuery request, CancellationToken cancellationToken)
        {
            return new ParkingClientView();
        }
    }
}
