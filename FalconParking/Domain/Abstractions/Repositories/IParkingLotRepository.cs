using FalconParking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Abstractions.Repositories
{
    public interface IParkingLotRepository : IInMemoryRepository<ParkingLot>
    {
    }
}
