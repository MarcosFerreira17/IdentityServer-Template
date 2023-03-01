using Microsoft.EntityFrameworkCore;
using IdentityServer.Domain.Entities;
using IdentityServer.Infrastructure.DataContext.Maps;

namespace IdentityServer.Infrastructure.DataContext;
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
    }
}