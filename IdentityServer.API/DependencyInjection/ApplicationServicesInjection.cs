using IdentityServer.Infrastructure.JwtConfiguration;
using IdentityServer.Infrastructure.Repositories;
using IdentityServer.Infrastructure.Repositories.Interfaces;
using IdentityServer.Infrastructure.Services;
using IdentityServer.Infrastructure.Services.Interfaces;

namespace IdentityServer.API.DependencyInjection;

public static class ApplicationServicesInjection
{
    public static void AddApplicationInfrastructure(this IServiceCollection services)
    {
        // services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<,>));
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
