using Domain.Events;
using System.Threading.Tasks;
using System.Threading;
using Domain.Abstractions.Repositories;
using Domain.Views;
using Domain.Entities;
using Application.Abstractions.Events;

namespace Application.Events.Handlers
{
    public class ParkingSlotEventHandlers :
        IDomainEventHandler<ParkingSlotOccupiedEvent>
        ,IDomainEventHandler<ParkingSlotFreedEvent>
        ,IDomainEventHandler<ParkingSlotReservedEvent>
    {
        private readonly IParkingSlotViewRepository _slotsRepository;

        public ParkingSlotEventHandlers(
            IParkingSlotViewRepository slotsRepository)
        {
            _slotsRepository = slotsRepository;
        }

        public async Task Handle(ParkingSlotOccupiedEvent e, CancellationToken cancellationToken)
        {
            var slotView = await _slotsRepository.GetByIdAsync(e.AggregateId);

            slotView.CurrentOccupantLicensePlate = e.OccupantLicensePlate;
            slotView.Status = (int)ParkingSlotStatus.Occuppied;

            await _slotsRepository.SaveAsync(slotView);
        }

        public async Task Handle(ParkingSlotFreedEvent e, CancellationToken cancellationToken)
        {
            var slotView = await _slotsRepository.GetByIdAsync(e.AggregateId);

            slotView.CurrentOccupantLicensePlate = null;
            slotView.Status = (int)ParkingSlotStatus.Available;

            await _slotsRepository.SaveAsync(slotView);
        }

        public async Task Handle(ParkingSlotReservedEvent e, CancellationToken cancellationToken)
        {
            var slotView = await _slotsRepository.GetByIdAsync(e.AggregateId);

            slotView.Status = (int)ParkingSlotStatus.Reserved;

            await _slotsRepository.SaveAsync(slotView);
        }
    }
}
