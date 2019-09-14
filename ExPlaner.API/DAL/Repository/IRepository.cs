using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExPlaner.API.DAL.Repository
{
    interface IRepository<T> where T : IEntity
    {
        void Insert(T entity);
        void Remove(T entity);
        IQueryable<T> GetAll();
        T GetById(Guid id);
    }
}
