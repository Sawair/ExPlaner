namespace ExPlaner.API.DAL.Repository
{
    public interface IUserDependentUnitOfWork<T> : IUnitOfWork<T> where T : IUserDependentEntity
    {
        IUserDependentRepository<T> GetUserDependentRepository();
    }
}