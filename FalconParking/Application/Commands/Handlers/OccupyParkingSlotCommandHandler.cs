using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Infrastructure.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Application.Commands.Handlers
{
    /// <summary>
    /// Handles the OccupyParkingSlotCommand
    /// </summary>
    public class OccupyParkingSlotCommandHandler : ICommandHandler<OccupyParkingSlotCommand, string>
    {
        private readonly IParkingLotRepository _repository;
        public OccupyParkingSlotCommandHandler(
            IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(
            OccupyParkingSlotCommand command
            ,CancellationToken token = new CancellationToken())
        {
            var parkingLot = _repository.Get(command.AggregateId);

            //TODO: Check if command.CarLicensePlate is registered to command.UserIdentification

            parkingLot.OcuppySlot(command.ParkingSlotId, command.CarLicensePlate);

            return "";
        }
    }
}
