﻿using FalconParking.Domain.Views;
using FalconParking.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure
{
    public class FalconParkingDbContext :  DbContext
    {
        public FalconParkingDbContext(
            DbContextOptions<FalconParkingDbContext> options) : base(options)
        {}

        public DbSet<ParkingLotView> ParkingLotViews { get; }
        public DbSet<ParkingSlotView> ParkingSlotViews { get; }
        public DbSet<ParkingLotEventModel> ParkingLotEvents { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLotView>().ToTable("lot_view", "parking");
            modelBuilder.Entity<ParkingSlotView>().ToTable("slot_view", "parking");

            modelBuilder.Entity<ParkingSlotView>()
                .HasKey(c => new { c.AggregateId, c.Id });
        }
    }
}
