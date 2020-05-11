using Domain.Abstractions.Repositories;
using Domain.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ParkingLotViewRepository : IParkingLotViewRepository
    {
        private readonly FalconParkingDbContext _context;

        public ParkingLotViewRepository(
            FalconParkingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ParkingLotView view)
        {
            _context.Add(view);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ParkingLotView>> GetAllAsync()
        {
            var view = await _context.ParkingLotViews
                .Include(sv => sv.Slots)
                .ToListAsync();

            return view;
        }

        public async Task<ParkingLotView> GetByIdAsync(Guid aggregateId)
        {
            var view = await _context.ParkingLotViews.FirstOrDefaultAsync(
                e => e.AggregateId == aggregateId
            );

            return view;
        }

        public async Task SaveAsync(ParkingLotView view)
        {
            view.UpdatedTime = DateTimeOffset.UtcNow;
            _context.Update(view);
            await _context.SaveChangesAsync();
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
