using Domain.Views;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class FalconParkingDbContext :  DbContext
    {
        public FalconParkingDbContext(
            DbContextOptions<FalconParkingDbContext> options) : base(options)
        {}

        public DbSet<ParkingLotEventModel> ParkingLotEvents { get; set; }
        public DbSet<ParkingLotView> ParkingLotViews { get; set; }
        public DbSet<ParkingSlotEventModel> ParkingSlotEvents { get; set; }
        public DbSet<ParkingSlotView> ParkingSlotViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Parking Lot View
            modelBuilder.Entity<ParkingLotView>()
                .ToTable("lot_view", "parking")
                .HasKey(lv => lv.AggregateId);
            //modelBuilder.Entity<ParkingLotView>()
                //.HasMany(lv => lv.Slots)
                //.WithOne(sv => sv.ParkingLot);

            //Parking Slot View
            modelBuilder.Entity<ParkingSlotView>()
                .ToTable("slot_view", "parking")
                .HasKey(s => s.AggregateId);
            modelBuilder.Entity<ParkingSlotView>()
                .HasOne(sv => sv.ParkingLot)
                .WithMany(lv => lv.Slots)
                .HasForeignKey(sv => sv.ParkingLotId);
        }
    }
}
