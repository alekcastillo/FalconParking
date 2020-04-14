using FalconParking.Infrastructure.Abstractions.Events;
using FalconParking.Domain.Events;
using System.Threading.Tasks;
using System.Threading;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Views;
using FalconParking.Domain.Events.Parking;
using FalconParking.Domain.Entities;

namespace FalconParking.Application.Events.Handlers
{
    public class ParkingSlotEventHandlers :
        IEventHandler<ParkingSlotOccupiedEvent>
    {
        private readonly IParkingSlotViewRepository _slotsRepository;

        public ParkingSlotEventHandlers(
            IParkingSlotViewRepository slotsRepository)
        {
            _slotsRepository = slotsRepository;
        }

        public async Task Handle(ParkingSlotOccupiedEvent notification, CancellationToken cancellationToken)
        {
            var view = new ParkingSlotView(
                notification.AggregateId
                ,(int) ParkingSlotStatus.Occuppied
                ,notification.TimeCreated
                ,notification.UserId.ToString());

            var slot = await _slotsRepository.GetByIdAsync(notification.AggregateId);


        }
    }
}
