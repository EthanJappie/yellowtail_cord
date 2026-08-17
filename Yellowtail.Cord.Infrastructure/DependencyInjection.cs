using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yellowtail.Cord.Infrastructure.Persistence;

namespace Yellowtail.Cord.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? "Data Source=Cord.db";

        services.AddDbContext<CordDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<CordDbContextInitializer>();

        return services;
    }
}
