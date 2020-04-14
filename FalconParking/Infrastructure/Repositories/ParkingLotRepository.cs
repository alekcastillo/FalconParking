﻿using System.Linq;
using FalconParking.Infrastructure.Events;
using FalconParking.Domain;
using FalconParking.Domain.Events;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Factories;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FalconParking.Infrastructure.Models;

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

        public async Task SaveAsync(ParkingLot aggregate)
        {
            var events = aggregate.GetUncommittedDomainEvents();
            if (events.Count < 1)
                return;

            var eventsToSave = events
                .Select(e => e.ToParkingLotEvent())
                .ToArray();

            context.ParkingLotEvents.AddRange(eventsToSave);
            await context.SaveChangesAsync();

            aggregate.CommitDomainEvents();
        }

        public async Task<ParkingLot> GetByIdAsync(int id)
        {
            var aggregate = ParkingLotFactory.CreateParkingLot(id);
            var events = await context.ParkingLotEvents.Where(
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
