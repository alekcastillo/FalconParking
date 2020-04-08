using FalconParking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Abstractions.Repositories
{
    public interface IAggregateRepository<TEntity> where TEntity : class
    {
        void Save(TEntity aggregate);

        TEntity GetById(int aggregateId);
    }
}
