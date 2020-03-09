using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FalconParking.Domain.Interfaces
{
    public interface IEventRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
    }
}
