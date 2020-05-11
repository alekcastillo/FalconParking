using Application.Abstractions;
using Application.Abstractions.Commands;
using Domain;
using Domain.Abstractions.Repositories;
using Domain.Events;
using Domain.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
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

        public async Task<Guid> Handle(AddParkingLotCommand cmd, CancellationToken cancellationToken = default)
        {
            var ReservableSlots = new int[] { 1, 2, 3, 5, 6 };
            var parkingLot = ParkingLot.New(
                cmd.Code
                ,cmd.TotalSlotsCount
                ,ReservableSlots);

            await _lotRepository.SaveAsync(parkingLot);

            // Guardamos los ids de los slots para luego
            // pasarlos al ParkingLotAndSlotsAddedEvent
            var slotIds = new Guid[cmd.TotalSlotsCount];

            for (int slotNumber = 1; slotNumber <= cmd.TotalSlotsCount; slotNumber++) {
                var parkingSlot = ParkingSlot.New(
                    parkingLot.AggregateId
                    ,slotNumber
                    ,ReservableSlots.Contains(slotNumber));

                slotIds[slotNumber - 1] = parkingSlot.AggregateId;
                await _slotRepository.SaveAsync(parkingSlot);
            }

            await _messageBus.PublishAsync(new ParkingLotAndSlotsAddedEvent(
                parkingLot.AggregateId
                ,DomainHelpers.GetSystemUser()
                ,slotIds
                ,ReservableSlots));

            return parkingLot.AggregateId;
        }

        public async Task<bool> Handle(OpenParkingLotCommand cmd, CancellationToken cancellationToken = default)
        {
            var parkingLot = await _lotRepository.GetByIdAsync(cmd.ParkingLotId);

            if (parkingLot.isOpen)
                throw new DomainException($"El parqueo {parkingLot.Code} ya esta abierto");

            parkingLot.Open(cmd.CurrentUserId);

            await _lotRepository.SaveAsync(parkingLot);

            return true;
        }

        public async Task<bool> Handle(CloseParkingLotCommand cmd, CancellationToken cancellationToken = default)
        {
            var parkingLot = await _lotRepository.GetByIdAsync(cmd.ParkingLotId);

            if (!parkingLot.isOpen)
                throw new DomainException($"El parqueo {parkingLot.Code} ya esta cerrado");

            parkingLot.Close(cmd.CurrentUserId);

            await _lotRepository.SaveAsync(parkingLot);

            return true;
        }
    }
}
