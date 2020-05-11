using Application.Abstractions.Queries;
using Domain.Abstractions.Repositories;
using Domain.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
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
