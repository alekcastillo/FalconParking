using System.Threading.Tasks;

namespace FalconParking.Domain.Abstractions.Repositories
{
    public interface IParkingSlotRepository
    {
        Task SaveAsync(ParkingSlot aggregate);
        Task<ParkingSlot> GetByIdAsync(int aggregateId);
    }
}
