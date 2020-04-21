using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Entities;
using FalconParking.Domain.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconParking.Infrastructure.Repositories
{
    public class ParkingSlotViewRepository : IParkingSlotViewRepository
    {
        private readonly FalconParkingDbContext _context;

        public ParkingSlotViewRepository(
            FalconParkingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ParkingSlotView view)
        {
            _context.Add(view);
            await _context.SaveChangesAsync();
        }

        public async Task<ParkingSlotView> GetByIdAsync(Guid aggregateId)
        {
            var view = await _context.ParkingSlotViews.FirstOrDefaultAsync(
                e => e.AggregateId == aggregateId
            );

            return view;
        }

        public async Task SaveAsync(ParkingSlotView view)
        {
            view.UpdatedTime = DateTimeOffset.UtcNow;
            _context.Update(view);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ParkingSlotView>> GetAllReservedAsync()
        {
            var views = await _context.ParkingSlotViews.Where(
                e => e.Status == (int) ParkingSlotStatus.Reserved
            ).ToListAsync();

            return views;
        }

        //public async Task DeleteByIdAsync(int id, int userId)
        //{
        //    var view = await GetByIdAsync(id);

        //    if (view != null)
        //    {
        //        view.DeletedTime =
        //        view.DeletedBy = userId;
        //    } else
        //        throw new KeyNotFoundException($"No hay ninguna SlotView con el id {id}");
        //}
    }
}
