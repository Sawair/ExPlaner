using ExPlaner.API.DAL.EF;

namespace ExPlaner.API.DAL.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        protected IRepository<T> _repo;
        protected AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> GetRepository()
        {
            return _repo ??= NewRepository();
        }

        protected virtual IRepository<T> NewRepository()
        {
            return new Repository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}