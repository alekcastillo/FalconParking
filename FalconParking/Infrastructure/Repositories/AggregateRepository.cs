using FalconParking.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FalconParking.Domain.Attributes;
using FalconParking.Domain.Entities;
using FalconParking.Infrastructure.Events;

namespace FalconParking.Infrastructure.Repositories
{
    public class AggregateRepository
    {
        private readonly FalconParkingDbContext context;

        public AggregateRepository(FalconParkingDbContext dbContext)
        {
            context = dbContext;
        }

        public void Save(Aggregate aggregate) //change to IAggregate
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

            aggregate.CommitDomainEvents();
        }

        public Aggregate GetById(int id)
        {
            var aggregate = new ParkingLot(
                id
                ,"A"
                ,0.00f
                ,0.00f
                ,30
                ,ParkingLotStatus.Open
                ,new ParkingSlot[30]);

            var events = from e in context.ParkingLotEvents
                       where e.AggregateId == id
                       select e;

            var eventsToApply = events.ToList<DomainEvent>()
                .Select(e => e.DeserializeEvent());

            aggregate.InitializeDomainEventHistory(eventsToApply);

            return aggregate;
        }
    }
}
