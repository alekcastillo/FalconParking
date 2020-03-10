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
    public class ParkingRepository : IInMemoryRepository<Lot>
    {
        private readonly List<Lot> _parkingLots;

        public ParkingRepository()
        {
            _parkingLots = new List<Lot>();
        }

        public void UseSlot(int parkingLotId)
        {
           // _parkingLots.Add(treatmentPlan);
        }

        public void ReserveSlot(int parkingLotId)
        {
            //_parkingLots.Add(treatmentPlan);
        }

        public void FreeSlot(int parkingLotId)
        {
            //_parkingLots.Add(treatmentPlan);
        }

        public Task<SlotOcuppation> FindSlotUsageAsync(Guid aggregateId, CancellationToken token = default)
        {
            return Task.FromResult(_parkingLots.FirstOrDefault(x => x.AggregateId == aggregateId));
        }

        public Task SaveAsync(CancellationToken token = default)
        {
            return Task.FromResult(true);
        }
    }
}
