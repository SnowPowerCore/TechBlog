using Microsoft.EntityFrameworkCore;
using PersonalTechBlog.Server.Models.Database.Base;
using PersonalTechBlog.Server.Models.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTechBlog.Server.Data.Repository.Database.Base
{
    public abstract class BaseDbRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected DbContext Context { get; private set; }

        protected BaseDbRepository(DbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await Context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) =>
            await Context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> FindAsync(ISpecification<T> specification) =>
            await Context.Set<T>()
                .Where(specification.IsSatisfiedBy())
                .ToListAsync();

        public Task AddOrUpdateAsync(T entity, uint? id = null)
        {
            if (null == id)
                Context.Set<T>().Add(entity);
            else
            {
                var exists = Context.Set<T>().AsNoTracking().Any(x => x.Id == id.Value);
                if (exists)
                    Context.Set<T>().Update(entity);
            }
            return Context.SaveChangesAsync();
        }

        public Task RemoveAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }
    }
}