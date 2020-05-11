using Domain.Abstractions.Repositories;
using Domain.Exceptions;
using Application.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    /// <summary>
    /// Handles the OccupyParkingSlotCommand
    /// </summary>
    public class ParkingSlotCommandHandlers :
        ICommandHandler<OccupyParkingSlotCommand, bool>
        ,ICommandHandler<FreeParkingSlotCommand, bool>
        ,ICommandHandler<ReserveParkingSlotCommand, bool>
    {
        private readonly IParkingLotRepository _lotRepository;
        private readonly IParkingSlotRepository _slotRepository;

        public ParkingSlotCommandHandlers(
            IParkingLotRepository lotRepository
            ,IParkingSlotRepository slotRepository)
        {
            _lotRepository = lotRepository;
            _slotRepository = slotRepository;
        }

        public async Task<bool> Handle(
            OccupyParkingSlotCommand cmd
            ,CancellationToken token = new CancellationToken())
        {
            var parkingSlot = await _slotRepository.GetByIdAsync(cmd.ParkingSlotId);
            var parkingLot = await _lotRepository.GetByIdAsync(parkingSlot.ParkingLotId);

            if (!parkingLot.isOpen)
                throw new DomainException($"El parqueo {parkingLot.Code} esta cerrado");

            if (!parkingSlot.IsAvailable)
                throw new DomainException($"El espacio {parkingSlot.SlotNumber} del parqueo {parkingLot.Code} no esta disponible");

            //TODO: Check if command.CarLicensePlate is registered to command.UserIdentification

            parkingSlot.Occupy(
                cmd.CurrentUserId
                ,cmd.CarLicensePlate);

            await _slotRepository.SaveAsync(parkingSlot);

            return true;
        }

        public async Task<bool> Handle(
            FreeParkingSlotCommand cmd
            ,CancellationToken token = new CancellationToken())
        {
            var parkingSlot = await _slotRepository.GetByIdAsync(cmd.ParkingSlotId);
            var parkingLot = await _lotRepository.GetByIdAsync(parkingSlot.ParkingLotId);

            if (!parkingLot.isOpen)
                throw new DomainException($"El parqueo {parkingLot.Code} esta cerrado");

            if (parkingSlot.IsAvailable)
                throw new DomainException($"El espacio {parkingSlot.SlotNumber} del parqueo {parkingLot.Code} ya esta disponible");

            //TODO: Check if command.CarLicensePlate is registered to command.UserIdentification

            parkingSlot.Free(
                cmd.CurrentUserId
                ,cmd.CarLicensePlate);

            await _slotRepository.SaveAsync(parkingSlot);

            return true;
        }

        public async Task<bool> Handle(
            ReserveParkingSlotCommand cmd
            ,CancellationToken token = new CancellationToken())
        {
            var parkingSlot = await _slotRepository.GetByIdAsync(cmd.ParkingSlotId);
            var parkingLot = await _lotRepository.GetByIdAsync(parkingSlot.ParkingLotId);

            if (!parkingLot.isOpen)
                throw new DomainException($"El parqueo {parkingLot.Code} esta cerrado");

            if (!parkingSlot.IsReservable)
                throw new DomainException($"El espacio {parkingSlot.SlotNumber} del parqueo {parkingLot.Code} no es reservable");

            if (!parkingSlot.IsAvailable)
                throw new DomainException($"El espacio {parkingSlot.SlotNumber} del parqueo {parkingLot.Code} no esta disponible");

            //TODO: Check if command.CarLicensePlate is registered to command.UserIdentification

            parkingSlot.Reserve(
                cmd.CurrentUserId
                ,cmd.ReservationTime);

            await _slotRepository.SaveAsync(parkingSlot);

            return true;
        }
    }
}
