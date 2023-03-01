using IdentityServer.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.API.DependencyInjection;

public static class DatabaseConfigurationInjection
{
    public static void AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
