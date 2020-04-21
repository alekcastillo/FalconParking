using FalconParking.Domain.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FalconParking.Domain.Abstractions.Repositories
{
    public interface IParkingSlotViewRepository
    {
        Task AddAsync(ParkingSlotView slotView);
        Task<ParkingSlotView> GetByIdAsync(Guid aggregateId);
        Task SaveAsync(ParkingSlotView slotView);
        Task<List<ParkingSlotView>> GetAllReservedAsync();
    }
}
