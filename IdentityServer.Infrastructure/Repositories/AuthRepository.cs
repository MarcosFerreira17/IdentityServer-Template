using IdentityServer.Domain.Entities;
using IdentityServer.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Repositories.Interfaces;

public class AuthRepository : BaseRepository<User, ApplicationDbContext>, IAuthRepository
{
    public AuthRepository(ApplicationDbContext context) : base(context) { }
    public override async Task Create(User entity)
    {
        await _context.Set<User>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<UserRole> GetRole()
    {
        var user = await _context.Set<User>().Include(i => i.UserRoles).ThenInclude(i => i.Role).FirstOrDefaultAsync();
        return user.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
    }
}
