using FalconParking.Domain;
using FalconParking.Domain.Interfaces;
using FalconParking.Domain.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;
using FalconParking.Domain.Abstractions.Repositories;

namespace FalconParking.Infrastructure.Commands.Handlers
{
    public class OccupyParkingSlotCommandHandler : ICommandHandler<OccupyParkingSlotCommand, int>
    {
        private readonly IParkingLotRepository _repository;

        public OccupyParkingSlotCommandHandler(
            IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            OccupyParkingSlotCommand command,
            CancellationToken token = new CancellationToken())
        {
            var parkingLot = _repository.Get(command.AggregateId);

            //TODO: Check if command.CarLicensePlate is registered to command.UserIdentification

            parkingLot.OcuppySlot(command.ParkingSlotId, command.CarLicensePlate);

            return 0;
        }
    }
}
