using FalconParking.Views;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Queries
{
    public class GetLotInformationQuery : IRequest<ParkingClientView>
    {
    }
}
