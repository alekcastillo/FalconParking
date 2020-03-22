using FalconParking.Domain;
using FalconParking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Infrastructure.Repositories
{
    public class ParkingLotRepository : IInMemoryRepository<ParkingLot>
    {
        private readonly ParkingLot[] _parkingLots;

        public ParkingLotRepository()
        {
            _parkingLots = new ParkingLot[3];
            _parkingLots[0] = new ParkingLot(0, "A", 0.0f, 0.0f, 20);
            _parkingLots[1] = new ParkingLot(1, "B", 0.0f, 0.0f, 10);
            _parkingLots[2] = new ParkingLot(2, "C", 0.0f, 0.0f, 5);
        }

        public ParkingLot Get(int id)
        {
            return _parkingLots[id - 1];
        }
    }
}
