using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Core.Context;

namespace YouTennis.Core.Respository
{
    public abstract class BaseAsync<T> : IBaseAsync<T> where T : class, IId, new()
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet { get { return Context.Set<T>(); } }

        public BaseAsync(ApiContext context)
        {
            Context = context;
        }

        public async Task<int> AddAsync(T model)
        {
            DbSet.Add(model);
            await Context.SaveChangesAsync();
            return model.Id;
        }

        public async Task DeleteAsync(T model)
        {
            DbSet.Remove(model);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> GetAsync(int id)
        {
            return await DbSet.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> UpdateAsync(T model)
        {
            DbSet.Update(model);
            await Context.SaveChangesAsync();
            return model;
        }
    }
}
