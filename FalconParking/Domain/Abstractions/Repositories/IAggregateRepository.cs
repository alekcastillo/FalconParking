namespace FalconParking.Domain.Abstractions.Repositories
{
    public interface IAggregateRepository<TEntity> where TEntity : class
    {
        void Save(TEntity aggregate);

        TEntity GetById(int aggregateId);
    }
}
