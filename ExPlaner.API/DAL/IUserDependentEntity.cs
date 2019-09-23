using ExPlaner.API.DAL.EF;

namespace ExPlaner.API.DAL
{
    public interface IUserDependentEntity : IEntity
    {
        AppUser User { get; set; }
    }
}