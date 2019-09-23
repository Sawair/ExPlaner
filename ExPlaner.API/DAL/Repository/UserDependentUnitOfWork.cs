using ExPlaner.API.DAL.EF;

namespace ExPlaner.API.DAL.Repository
{
    public class UserDependentUnitOfWork<T> : UnitOfWork<T>, IUserDependentUnitOfWork<T> where T : class, IUserDependentEntity
    {
        public UserDependentUnitOfWork(AppDbContext context) : base(context)
        {
        }

        protected override IRepository<T> NewRepository()
        {
            return new UserDependentRepository<T>(_context);
        }

        public IUserDependentRepository<T> GetUserDependentRepository()
        {
            return base.GetRepository() as IUserDependentRepository<T>;
        }
    }
}