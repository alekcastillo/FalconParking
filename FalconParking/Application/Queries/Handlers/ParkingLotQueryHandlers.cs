using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Views;
using FalconParking.Infrastructure.Abstractions.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Application.Queries.Handlers
{
    public class ParkingLotQueryHandlers : IQueryHandler<GetParkingLotsInfoQuery, IEnumerable<ParkingLotView>>
    {
        private readonly IParkingLotViewRepository _repo;

        public ParkingLotQueryHandlers(
            IParkingLotViewRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ParkingLotView>> Handle(GetParkingLotsInfoQuery query, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
