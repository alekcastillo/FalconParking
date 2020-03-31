using FalconParking.Domain.Views;
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
        {

        }

        public DbSet<ParkingLotView> ParkingLotViews { get; set; }
        public DbSet<ParkingSlotView> ParkingSlotViews { get; set; }
        public DbSet<ParkingLotEvent> ParkingLotEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ParkingLotView>().ToTable("Customers", schemaName: "Ordering");

            modelBuilder.Entity<ParkingSlotView>()
                .HasKey(c => new { c.AggregateId, c.Id });
        }
    }
}
