using System.Linq;
using ExPlaner.API.DAL.EF;

namespace ExPlaner.API.DAL.Repository
{
    public interface IUserDependentRepository<T> : IRepository<T> where T : IUserDependentEntity
    {
        IQueryable<T> GetAllByUser(AppUser user);
        IQueryable<T> GetAllPagedByUser(AppUser user, int pageNumber, int pageSize);
    }
}