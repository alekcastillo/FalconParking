using FalconParking.Domain;
using FalconParking.Domain.Interfaces;
using FalconParking.Domain.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;
using FalconParking.Domain.Abstractions.Repositories;

namespace FalconParking.Infrastructure.Commands.Handlers
{
    public class FreeParkingSlotCommandHandler : ICommandHandler<FreeParkingSlotCommand, int>
    {
        private readonly IParkingLotRepository _repository;

        public FreeParkingSlotCommandHandler(
            IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            FreeParkingSlotCommand command,
            CancellationToken token = new CancellationToken())
        {
            var parkingLot = _repository.Get(command.AggregateId);

            //TODO: Check if command.CarLicensePlate is registered to command.UserIdentification

            parkingLot.ReserveSlot(command.ParkingSlotId, command.CarLicensePlate, Domain.Entities.ParkingSlotReservationTime.HalfHour);

            return 0;
        }
    }
}
