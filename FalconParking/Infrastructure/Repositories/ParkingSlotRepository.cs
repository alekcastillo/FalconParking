﻿using System.Linq;
using FalconParking.Infrastructure.Events;
using FalconParking.Domain;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Factories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FalconParking.Infrastructure.Abstractions;
using System.Collections.Generic;
using System;

namespace FalconParking.Infrastructure.Repositories
{
    public class ParkingSlotRepository : IParkingSlotRepository
    {
        private readonly FalconParkingDbContext _context;
        private readonly IMessageBus _messageBus;

        public ParkingSlotRepository(
            FalconParkingDbContext context
            ,IMessageBus messageBus)
        {
            _context = context;
            _messageBus = messageBus;
        }

        public async Task<ParkingSlot> GetByIdAsync(Guid aggregateId)
        {
            var aggregate = AggregateFactory.CreateParkingSlot(aggregateId);
            var events = await _context.ParkingSlotEvents.Where(
                    e => e.AggregateId == aggregateId
                ).OrderBy(
                    e => e.CreatedTime
                ).ToListAsync();
            var eventsToApply = events.Select(e => e.DeserializeEvent());

            aggregate.InitializeDomainEventHistory(eventsToApply);

            return aggregate;
        }

        public async Task SaveAsync(ParkingSlot aggregate)
        {
            var events = aggregate.GetUncommittedDomainEvents();
            if (events.Count < 1)
                return;

            await _messageBus.PublishRangeAsync(events);

            var eventsToSave = events.Select(
                    e => e.ToParkingSlotEvent()
                ).ToArray();

            _context.ParkingSlotEvents.AddRange(eventsToSave);
            await _context.SaveChangesAsync();

            aggregate.CommitDomainEvents();
        }
    }
}
