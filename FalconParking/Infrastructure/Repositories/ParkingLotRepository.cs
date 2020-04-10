using System.Linq;
using FalconParking.Infrastructure.Events;
using FalconParking.Domain;
using FalconParking.Domain.Events;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Factories;
using System;

namespace FalconParking.Infrastructure.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly FalconParkingDbContext context;

        public ParkingLotRepository(
            FalconParkingDbContext dbContext)
        {
            context = dbContext;
        }

        //MAKE ASYNC

        public void Save(ParkingLot aggregate) //change to IAggregate
        {
            var events = aggregate.GetUncommittedDomainEvents();
            if (events.Count < 1)
                return;

            var aggregateType = aggregate.GetType().Name;

            var eventsToSave = events
                .Select(e => e.ToEventModel())
                .ToArray();
            // more code...

            context.ParkingLotEvents.AddRange(eventsToSave);
            context.SaveChanges();

            aggregate.CommitDomainEvents();
        }

        public ParkingLot GetById(int id)
        {
            var aggregate = ParkingLotFactory.CreateParkingLot(id);

            var events = from e in context.ParkingLotEvents
                       where e.AggregateId == id - 1
                       //orderby e.
                       select e;

            var eventsToApply = events.ToList()
                .Select(e => e.DeserializeEvent());

            aggregate.InitializeDomainEventHistory(eventsToApply);

            return aggregate;
        }
    }
}
