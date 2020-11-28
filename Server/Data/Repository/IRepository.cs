using PersonalTechBlog.Server.Models.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalTechBlog.Server.Data.Repository
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification);

        Task AddOrUpdateAsync(TEntity entity, uint? id = null);

        Task RemoveAsync(TEntity entity);
    }
}