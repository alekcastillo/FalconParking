using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconParking.Infrastructure.Repositories
{
    class ParkingSlotViewRepository : IParkingSlotViewRepository
    {
        private readonly FalconParkingDbContext context;

        public ParkingSlotViewRepository(
            FalconParkingDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<ParkingSlotView> GetByIdAsync(int aggregateId, int id)
        {
            var view = await context.ParkingSlotViews.FirstOrDefaultAsync(
                e => e.AggregateId == aggregateId && e.Id == id
            );

            return view;
        }

        public async Task SaveAsync(ParkingSlotView view)
        {
            var existingView = await GetByIdAsync(view.AggregateId, view.Id);

            if (existingView != null) {
                existingView.Status = view.Status;
                existingView.UpdatedBy = view.UpdatedBy;
                existingView.UpdatedTime = view.UpdatedTime;
            } else
                context.Add(view);

            await context.SaveChangesAsync();
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
