using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Domain.Interfaces
{
    public interface IInMemoryRepository<TEntity> where TEntity : class
    {
        TEntity Get(int aggregateId);
    }
}
