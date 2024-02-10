using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Api.Repository
{
    public interface IRepository<TEntity>
    {

        Task Add(TEntity entity);

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity;
        Task Save();

    }
}
