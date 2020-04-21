using FalconParking.Domain;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Events;
using FalconParking.Domain.Exceptions;
using FalconParking.Infrastructure.Abstractions;
using FalconParking.Infrastructure.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Application.Commands.Handlers
{
    /// <summary>
    /// Handles the OccupyParkingSlotCommand
    /// </summary>
    public class ParkingLotCommandHandlers :
        ICommandHandler<AddParkingLotCommand, Guid>
        ,ICommandHandler<OpenParkingLotCommand, bool>
        ,ICommandHandler<CloseParkingLotCommand, bool>
    {
        private readonly IParkingLotRepository _lotRepository;
        private readonly IParkingSlotRepository _slotRepository;
        private readonly IMessageBus _messageBus;

        public ParkingLotCommandHandlers(
            IParkingLotRepository lotRepository
            ,IParkingSlotRepository slotRepository
            ,IMessageBus messageBus)
        {
            _lotRepository = lotRepository;
            _slotRepository = slotRepository;
            _messageBus = messageBus;
        }

        public async Task<Guid> Handle(
            AddParkingLotCommand command
            ,CancellationToken cancellationToken = default)
        {
            var ReservableSlots = new int[] { 1, 2, 3, 5, 6 };
            var parkingLot = ParkingLot.New(
                command.Code
                ,command.TotalSlotsCount
                ,ReservableSlots);

            await _lotRepository.SaveAsync(parkingLot);

            // Guardamos los ids de los slots para luego
            // pasarlos al ParkingLotAndSlotsAddedEvent
            var slotIds = new Guid[command.TotalSlotsCount];

            for (int slotNumber = 1; slotNumber <= command.TotalSlotsCount; slotNumber++) {
                var parkingSlot = ParkingSlot.New(
                    parkingLot.AggregateId
                    ,slotNumber
                    ,ReservableSlots.Contains(slotNumber));

                slotIds[slotNumber - 1] = parkingSlot.AggregateId;
                await _slotRepository.SaveAsync(parkingSlot);
            }

            await _messageBus.PublishAsync(new ParkingLotAndSlotsAddedEvent(
                parkingLot.AggregateId
                ,slotIds
                ,ReservableSlots
                ,DomainHelpers.GetSystemUser()));

            return parkingLot.AggregateId;
        }

        public async Task<bool> Handle(
            OpenParkingLotCommand command
            ,CancellationToken cancellationToken = default)
        {
            var parkingLot = await _lotRepository.GetByIdAsync(command.ParkingLotId);

            if (parkingLot.isOpen)
                throw new DomainException($"El parqueo {parkingLot.Code} ya esta abierto");

            parkingLot.Open(command.CurrentUserId);

            await _lotRepository.SaveAsync(parkingLot);

            return true;
        }

        public async Task<bool> Handle(
            CloseParkingLotCommand command
            ,CancellationToken cancellationToken = default)
        {
            var parkingLot = await _lotRepository.GetByIdAsync(command.ParkingLotId);

            if (!parkingLot.isOpen)
                throw new DomainException($"El parqueo {parkingLot.Code} ya esta cerrado");

            parkingLot.Close(command.CurrentUserId);

            await _lotRepository.SaveAsync(parkingLot);

            return true;
        }
    }
}
