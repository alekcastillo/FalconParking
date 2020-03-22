using FalconParking.Domain;
using FalconParking.Domain.Interfaces;
using FalconParking.Domain.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Infrastructure.Commands.Handlers
{
    public class OccupyParkingSlotCommandHandler : ICommandHandler<OccupyParkingSlotCommand, int>
    {
        private readonly IInMemoryRepository<ParkingLot> _repository;

        public OccupyParkingSlotCommandHandler(
            IInMemoryRepository<ParkingLot> repository)
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
