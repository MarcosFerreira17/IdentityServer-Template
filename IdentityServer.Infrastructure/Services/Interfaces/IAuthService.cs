using IdentityServer.Domain.Dtos;

namespace IdentityServer.Infrastructure.Services.Interfaces;

public interface IAuthService
{
    Task<IEnumerable<UserListDto>> GetAll();
    Task<UserDetailsDto> GetById(long id);
    Task Add(UserRegisterDto entity);
    Task Update(long id, UserDetailsDto entity);
    Task Delete(long id);
    Task<string> Login(UserLoginDto request);
}
