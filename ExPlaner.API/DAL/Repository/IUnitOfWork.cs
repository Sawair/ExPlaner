using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPlaner.API.DAL.Repository
{
    public interface IUnitOfWork<T> : IDisposable where T : IEntity
    {
        IRepository<T> GetRepository();
        void Save();

    }
}
