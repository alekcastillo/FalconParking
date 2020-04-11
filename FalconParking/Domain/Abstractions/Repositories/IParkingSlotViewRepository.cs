using FalconParking.Domain.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FalconParking.Domain.Abstractions.Repositories
{
    public interface IParkingSlotViewRepository
    {
        Task<ParkingSlotView> GetByIdAsync(int aggregateId, int slotId);
        Task SaveAsync(ParkingSlotView slotView);
    }
}
