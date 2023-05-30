using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;

namespace YouTennis.Core.Respository
{
    public abstract class Base<T> : IBase<T> where T : class, IId, new()
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet { get { return Context.Set<T>();  } }

        public Base(DbContext context)
        {
            Context = context;
        }

        public int Add(T model)
        {
            DbSet.Add(model);
            Context.SaveChanges();

            return model.Id;
        }

        public void Delete(T model)
        {
            DbSet.Remove(model);
            Context.SaveChanges();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToListAsync().Result;
        }

        public T Update(T model)
        {
            DbSet.Update(model);
            Context.SaveChanges();

            return model;
        }
    }
}
