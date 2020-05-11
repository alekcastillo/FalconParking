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
    //THIS IS WIP
    public class ViewRepository<TEntity> where TEntity : class
    {
        private readonly FalconParkingDbContext context;

        public ViewRepository(
            FalconParkingDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task AddAsync(TEntity view)
        {
            //var existingView = await GetByIdAsync(view.AggregateId);

            //if (existingView == null)
                //context.Add(view);
        }

        //public async Task<TEntity> GetByIdAsync(Guid aggregateId)
        //{
            //var view = await context.Set<TEntity>().FirstOrDefaultAsync(
                //e => e.AggregateId == aggregateId
            //);

            //return view;
        //}

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
