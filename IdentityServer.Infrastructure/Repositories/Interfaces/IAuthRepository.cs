using IdentityServer.Domain.Entities;

namespace IdentityServer.Infrastructure.Repositories.Interfaces;
public interface IAuthRepository : IBaseRepository<User>
{
    Task<UserRole> GetRole();
}
