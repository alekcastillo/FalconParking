using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Infrastructure.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Application.Commands.Handlers
{
    /// <summary>
    /// Handles the OccupyParkingSlotCommand
    /// </summary>
    public class ParkingSlotCommandHandlers :
        ICommandHandler<OccupyParkingSlotCommand, string>
        //,ICommandHandler<FreeParkingSlotCommand, string>
    {
        private readonly IParkingLotRepository _repository;
        public ParkingSlotCommandHandlers(
            IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(
            OccupyParkingSlotCommand command
            ,CancellationToken token = new CancellationToken())
        {
            var parkingLot = await _repository.GetByIdAsync(command.AggregateId);

            //TODO: Check if command.CarLicensePlate is registered to command.UserIdentification

            parkingLot.OcuppySlot(command.ParkingSlotId, command.CarLicensePlate);

            await _repository.SaveAsync(parkingLot);

            return "";
        }
    }
}
