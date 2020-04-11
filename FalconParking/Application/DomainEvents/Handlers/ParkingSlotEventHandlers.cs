using FalconParking.Infrastructure.Abstractions.Events;
using FalconParking.Domain.Events;
using System.Threading.Tasks;
using System.Threading;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Views;

namespace FalconParking.Application.Events.Handlers
{
    public class ParkingSlotEventHandlers :
        IEventHandler<ParkingSlotOcuppiedEvent>
    {
        private readonly IParkingSlotViewRepository _slotsRepository;

        public ParkingSlotEventHandlers(
            IParkingSlotViewRepository slotsRepository)
        {
            _slotsRepository = slotsRepository;
        }

        public async Task Handle(ParkingSlotOcuppiedEvent notification, CancellationToken cancellationToken)
        {
            var slot = await _slotsRepository.GetByIdAsync(notification.AggregateId, notification.ParkingSlotId);


        }
    }
}
