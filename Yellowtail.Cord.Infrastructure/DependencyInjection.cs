using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yellowtail.Cord.Application.Common.Interfaces;
using Yellowtail.Cord.Infrastructure.Persistence;
using Yellowtail.Cord.Infrastructure.Services;

namespace Yellowtail.Cord.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? "Data Source=Cord.db";

        services.AddDbContext<CordDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<ITenantProvider, TenantProvider>();
        services.AddScoped<CordDbContextInitializer>();

        return services;
    }
}
