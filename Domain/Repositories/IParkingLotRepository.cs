using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IParkingLotRepository
    {
        Task SaveAsync(ParkingLot aggregate, CancellationToken cancellationToken = default);
        Task<ParkingLot> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken = default);
    }
}
