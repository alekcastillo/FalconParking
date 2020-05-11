using Domain.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IParkingLotViewRepository
    {
        Task AddAsync(ParkingLotView slotView);
        Task<IEnumerable<ParkingLotView>> GetAllAsync();
        Task<ParkingLotView> GetByIdAsync(Guid aggregateId);
        Task SaveAsync(ParkingLotView slotView);
    }
}
