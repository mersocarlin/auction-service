using System.Collections.Generic;

namespace AuctionService.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Dispose();
    }
}
