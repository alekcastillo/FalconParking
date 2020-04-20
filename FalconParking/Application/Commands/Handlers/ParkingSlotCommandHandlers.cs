﻿using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Exceptions;
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
        private readonly IParkingLotRepository _lotRepository;
        private readonly IParkingSlotRepository _slotRepository;

        public ParkingSlotCommandHandlers(
            IParkingLotRepository lotRepository
            ,IParkingSlotRepository slotRepository)
        {
            _lotRepository = lotRepository;
            _slotRepository = slotRepository;
        }

        public async Task<string> Handle(
            OccupyParkingSlotCommand command
            ,CancellationToken token = new CancellationToken())
        {

            var parkingSlot = await _slotRepository.GetByIdAsync(command.AggregateId);
            var parkingLot = await _lotRepository.GetByIdAsync(parkingSlot.ParkingLotId);

            if (!parkingLot.isOpen)
                throw new DomainException($"El parqueo {parkingLot.Code} no esta disponible");

            if (!parkingSlot.isAvailable)
                throw new DomainException($"El espacio {parkingSlot.SlotNumber} del parqueo {parkingLot.Code} no esta disponible");

            //TODO: Check if command.CarLicensePlate is registered to command.UserIdentification

            parkingSlot.Occupy(
                command.UserId
                ,command.CarLicensePlate);

            await _slotRepository.SaveAsync(parkingSlot);

            return "";
        }
    }
}