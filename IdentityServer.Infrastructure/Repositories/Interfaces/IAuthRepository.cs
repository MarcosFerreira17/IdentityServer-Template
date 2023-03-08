using IdentityServer.Domain.Entities.Identity;

namespace IdentityServer.Infrastructure.Repositories.Interfaces;
public interface IAuthRepository : IBaseRepository<User>
{
    Task CreateUser(User entity);
    Task<Role> GetRole();
}
