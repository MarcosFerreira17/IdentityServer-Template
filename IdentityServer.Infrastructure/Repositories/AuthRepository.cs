using IdentityServer.Domain.Entities;
using IdentityServer.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Repositories.Interfaces;

public class AuthRepository : BaseRepository<User, ApplicationDbContext>, IAuthRepository
{
    public AuthRepository(ApplicationDbContext context) : base(context) { }
    public override async Task Create(User entity)
    {
        entity.RoleId = 1; // default add user in user role.
        await _context.Set<User>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Role> GetRole(long roleId)
    {
        return await _context.Set<Role>().Where(i => i.Id == roleId).FirstOrDefaultAsync();
    }
}
