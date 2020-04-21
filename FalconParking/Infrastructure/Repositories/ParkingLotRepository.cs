﻿using System.Linq;
using FalconParking.Infrastructure.Events;
using FalconParking.Domain;
using FalconParking.Domain.Events;
using FalconParking.Domain.Abstractions.Repositories;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FalconParking.Infrastructure.Models;
using FalconParking.Infrastructure.Abstractions;
using System.Threading;
using FalconParking.Domain.Factories;

namespace FalconParking.Infrastructure.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly FalconParkingDbContext _context;
        private readonly IMessageBus _messageBus;

        public ParkingLotRepository(
            FalconParkingDbContext context
            ,IMessageBus messageBus)
        {
            _context = context;
            _messageBus = messageBus;
        }

        public async Task<ParkingLot> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken = default)
        {
            var aggregate = AggregateFactory.CreateParkingLot(aggregateId);
            var events = await _context.ParkingLotEvents.Where(
                    e => e.AggregateId == aggregateId
                ).OrderBy(
                    e => e.CreatedTime
                ).ToListAsync();
            var eventsToApply = events.Select(e => e.DeserializeEvent());

            aggregate.InitializeDomainEventHistory(eventsToApply);

            return aggregate;
        }

        public async Task SaveAsync(ParkingLot aggregate, CancellationToken cancellationToken = default)
        {
            var events = aggregate.GetUncommittedDomainEvents();
            if (events.Count < 1)
                return;

            await _messageBus.PublishRangeAsync(events);

            var eventsToSave = events.Select(
                    e => e.ToParkingLotEvent()
                ).ToArray();

            _context.ParkingLotEvents.AddRange(eventsToSave);
            await _context.SaveChangesAsync();

            aggregate.CommitDomainEvents();
        }
    }
}
