using Microsoft.EntityFrameworkCore;

namespace Yellowtail.Cord.Infrastructure.Persistence;

public class CordDbContext : DbContext
{
    public CordDbContext(DbContextOptions<CordDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CordDbContext).Assembly);
    }
}
