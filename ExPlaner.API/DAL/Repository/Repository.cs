using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExPlaner.API.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace ExPlaner.API.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbSet<T> DataSet;

        public Repository(AppDbContext dbContext)
        {
            DataSet = dbContext.Set<T>();
        }

        public void Insert(T entity)
        {
            DataSet.Add(entity);
        }

        public void Remove(T entity)
        {
            DataSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DataSet;
        }

        public T GetById(Guid id)
        {
            return DataSet.SingleOrDefault(e => e.Id.Equals(id));
        }
    }
}
