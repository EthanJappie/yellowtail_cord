using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Yellowtail.Cord.Infrastructure.Persistence;

public class CordDbContextInitializer
{
    private readonly CordDbContext _context;
    private readonly ILogger<CordDbContextInitializer> _logger;

    public CordDbContextInitializer(CordDbContext context, ILogger<CordDbContextInitializer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Ensuring SQLite database is created and up to date...");
            await _context.Database.EnsureCreatedAsync(cancellationToken);
            _logger.LogInformation("SQLite database initialization completed successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the SQLite database.");
            throw;
        }
    }
}

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
    {
        using var scope = serviceProvider.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<CordDbContextInitializer>();
        await initializer.InitializeAsync(cancellationToken);
    }
}
