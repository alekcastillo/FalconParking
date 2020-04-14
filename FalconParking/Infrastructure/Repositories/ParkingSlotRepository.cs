using System.Linq;
using FalconParking.Infrastructure.Events;
using FalconParking.Domain;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Factories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FalconParking.Infrastructure.Repositories
{
    public class ParkingSlotRepository : IParkingSlotRepository
    {
        private readonly FalconParkingDbContext context;

        public ParkingSlotRepository(
            FalconParkingDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task SaveAsync(ParkingSlot aggregate)
        {
            var events = aggregate.GetUncommittedDomainEvents();
            if (events.Count < 1)
                return;

            var eventsToSave = events.Select(
                    e => e.ToParkingSlotEvent()
                ).ToArray();

            context.ParkingSlotEvents.AddRange(eventsToSave);
            await context.SaveChangesAsync();

            aggregate.CommitDomainEvents();
        }

        public async Task<ParkingSlot> GetByIdAsync(int id)
        {
            var aggregate = ParkingSlotFactory.CreateParkingSlot(id);
            var events = await context.ParkingSlotEvents.Where(
                    e => e.AggregateId == id
                ).OrderBy(
                    e => e.CreatedTime
                ).ToListAsync();
            var eventsToApply = events.Select(e => e.DeserializeEvent());

            aggregate.InitializeDomainEventHistory(eventsToApply);

            return aggregate;
        }
    }
}
