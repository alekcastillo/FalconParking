using FalconParking.Infrastructure.Abstractions.Events;
using FalconParking.Domain.Events;
using System.Threading.Tasks;
using System.Threading;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Views;
using FalconParking.Domain.Entities;

namespace FalconParking.Application.Events.Handlers
{
    public class ParkingSlotEventHandlers :
        IEventHandler<ParkingSlotOccupiedEvent>
        ,IEventHandler<ParkingSlotFreedEvent>
        ,IEventHandler<ParkingSlotReservedEvent>
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
