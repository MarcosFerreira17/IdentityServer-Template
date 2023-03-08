using IdentityServer.Domain.Entities.Identity;
using IdentityServer.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Repositories.Interfaces;

public class AuthRepository : BaseRepository<User, ApplicationDbContext>, IAuthRepository
{
    public AuthRepository(ApplicationDbContext context) : base(context) { }
    public async Task CreateUser(User entity)
    {
        await _context.Set<User>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Role> GetRole()
    {
        var user = await _context.Set<Role>().FirstOrDefaultAsync();
        return user;
    }
}
