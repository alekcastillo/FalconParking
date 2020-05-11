using Domain.Events;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using Application.Abstractions.Events;
using Domain.Abstractions.Repositories;
using Domain.Views;
using Domain.Attributes;
using Domain.Entities;
using Domain;

namespace Application.Events.Handlers
{
    public class ParkingLotEventHandlers :
        IDomainEventHandler<ParkingLotAddedEvent>
        ,IDomainEventHandler<ParkingLotAndSlotsAddedEvent>
        ,IDomainEventHandler<ParkingLotOpenedEvent>
        ,IDomainEventHandler<ParkingLotClosedEvent>
    {
        private readonly IParkingLotViewRepository _lotViewRepository;
        private readonly IParkingSlotViewRepository _slotViewRepository;

        public ParkingLotEventHandlers(
            IParkingLotViewRepository lotViewRepository
            ,IParkingSlotViewRepository slotViewRepository)
        {
            _lotViewRepository = lotViewRepository;
            _slotViewRepository = slotViewRepository;
        }

        public async Task Handle(ParkingLotAddedEvent e, CancellationToken cancellationToken)
        {
            var lotView = new ParkingLotView(
                e.AggregateId
                ,e.Code
                ,e.TotalSlotsCount
                ,e.TotalSlotsCount
                ,(int)ParkingLotStatus.Open
                ,new List<ParkingSlotView>()
                ,e.TimeCreated
                ,e.CurrentUserId);

            await _lotViewRepository.AddAsync(lotView);
        }

        public async Task Handle(ParkingLotAndSlotsAddedEvent e, CancellationToken cancellationToken)
        {
            var lotView = await _lotViewRepository.GetByIdAsync(e.AggregateId);

            for (int slotNumber = 1; slotNumber <= e.ParkingSlotIds.Length; slotNumber++)
            {
                var slotView = new ParkingSlotView(
                    e.ParkingSlotIds[slotNumber - 1]
                    ,lotView.AggregateId
                    ,lotView
                    ,slotNumber
                    ,(int)ParkingSlotStatus.Available
                    ,e.ReservableSlots.Contains(slotNumber)
                    ,null
                    ,e.TimeCreated
                    ,DomainHelpers.GetSystemUser());
                await _slotViewRepository.AddAsync(slotView);
            }
        }

        public async Task Handle(ParkingLotOpenedEvent e, CancellationToken cancellationToken)
        {
            var lotView = await _lotViewRepository.GetByIdAsync(e.AggregateId);

            lotView.Status = (int)ParkingLotStatus.Open;
            lotView.UpdatedBy = e.CurrentUserId;

            await _lotViewRepository.SaveAsync(lotView);
        }

        public async Task Handle(ParkingLotClosedEvent e, CancellationToken cancellationToken)
        {
            var lotView = await _lotViewRepository.GetByIdAsync(e.AggregateId);

            lotView.Status = (int)ParkingLotStatus.Closed;
            lotView.UpdatedBy = e.CurrentUserId;

            await _lotViewRepository.SaveAsync(lotView);
        }
    }
}
