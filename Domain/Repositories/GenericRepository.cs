using Domain.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Domain.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext dbContext;
        protected DbSet<T> objectSet;

        public GenericRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
            objectSet = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return objectSet.Where(predicate);
            }

            return objectSet.AsEnumerable();
        }

        public T Get(Func<T, bool> predicate)
        {
            return objectSet.First(predicate);
        }

        public void Insert(T entity)
        {
            objectSet.Add(entity);
        }

        public void Update(T entity)
        {
            objectSet.AddOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            objectSet.Remove(entity);
        }

        public void SaveChanges()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    dbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }
    }
}

