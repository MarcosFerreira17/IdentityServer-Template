using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Domain.Entities.Identity;
using Microsoft.Extensions.Logging;

namespace IdentityServer.Infrastructure.DataContext;

public class ApplicationContextSeed
{

    public static async Task SeedAsync(ApplicationDbContext applicationContext, ILogger<ApplicationContextSeed> logger)
    {
        if (!applicationContext.Users.Any())
        {
            applicationContext.Roles.AddRange(GetPreconfiguredRoles());
            applicationContext.Users.AddRange(GetPreconfiguredUsers());
            await applicationContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with applicationContext");
        }
    }

    private static IEnumerable<User> GetPreconfiguredUsers()
    {
        return new List<User>
            {
                new User("admin", "admin@localhost", "admin", "Admin", "Admin", "Admin", DateTime.Now, "https://localhost:5001/images/avatars/avatar-1.png", 1)
            };
    }
    private static IEnumerable<Role> GetPreconfiguredRoles()
    {
        return new List<Role>
            {
                new Role("admin","desc")
            };
    }
}
