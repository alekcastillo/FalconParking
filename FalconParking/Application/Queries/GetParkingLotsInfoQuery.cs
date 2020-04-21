using FalconParking.Domain.Views;
using FalconParking.Infrastructure.Abstractions.Queries;
using System;
using System.Collections.Generic;

namespace FalconParking.Application.Queries
{
    public class GetParkingLotsInfoQuery : IQuery<IEnumerable<ParkingLotView>>
    {

        public GetParkingLotsInfoQuery() { }
    }
}
