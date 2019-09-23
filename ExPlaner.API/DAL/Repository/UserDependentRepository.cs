using System.Linq;
using ExPlaner.API.DAL.EF;
using ExPlaner.API.Helper;

namespace ExPlaner.API.DAL.Repository
{
    public class UserDependentRepository<T> : Repository<T>, IUserDependentRepository<T>
        where T : class, IUserDependentEntity
    {
        public UserDependentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<T> GetAllByUser(AppUser user)
        {
            return GetAll().Where(e => e.User.Equals(user));
        }

        public IQueryable<T> GetAllPagedByUser(AppUser user, int pageNumber, int pageSize)
        {
            return GetAllByUser(user)
                .Paging(pageNumber, pageSize);
        }
    }
}