using IdentityServer.Domain.Dtos;

namespace IdentityServer.Infrastructure.Services.Interfaces;

public interface IAuthService : IBaseService<UserDto, long>
{
    Task<string> Login(UserDto request);
}
