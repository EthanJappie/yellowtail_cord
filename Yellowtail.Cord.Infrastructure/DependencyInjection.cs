using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yellowtail.Cord.Application.Common.Interfaces;
using Yellowtail.Cord.Infrastructure.Persistence;
using Yellowtail.Cord.Infrastructure.Persistence.Interceptors;
using Yellowtail.Cord.Infrastructure.Services;

namespace Yellowtail.Cord.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? "Data Source=Cord.db";

        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
        services.AddScoped<AuditableEntityInterceptor>();

        services.AddDbContext<CordDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetRequiredService<AuditableEntityInterceptor>());
            options.UseSqlite(connectionString, builder => 
                builder.MigrationsAssembly(typeof(CordDbContext).Assembly.FullName));
        });

        services.AddScoped<ITenantProvider, TenantProvider>();
        services.AddScoped<CordDbContextInitializer>();

        return services;
    }
}
