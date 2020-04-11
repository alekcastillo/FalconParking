using System.Threading.Tasks;

namespace FalconParking.Domain.Abstractions.Repositories
{
    public interface IParkingLotRepository
    {
        Task SaveAsync(ParkingLot aggregate);
        Task<ParkingLot> GetByIdAsync(int aggregateId);
    }
}
