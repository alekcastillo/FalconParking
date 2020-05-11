using System;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IParkingSlotRepository
    {
        Task SaveAsync(ParkingSlot aggregate);
        Task<ParkingSlot> GetByIdAsync(Guid aggregateId);
    }
}
