using Application.Abstractions.Queries;
using Domain.Views;
using System;
using System.Collections.Generic;

namespace Application.Queries
{
    public class GetParkingLotsInfoQuery : IQuery<IEnumerable<ParkingLotView>>
    {

        public GetParkingLotsInfoQuery() { }
    }
}
