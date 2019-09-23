using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExPlaner.API.DAL.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        void Insert(T entity);
        void Remove(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllPaged(int pageNumber, int pageSize);
        T GetById(Guid id);
    }
}
