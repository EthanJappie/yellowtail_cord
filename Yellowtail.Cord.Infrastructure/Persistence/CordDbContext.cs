using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence;

public class CordDbContext : DbContext
{
    public CordDbContext(DbContextOptions<CordDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<Sport> Sports => Set<Sport>();
    public DbSet<MemberSport> MemberSports => Set<MemberSport>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CordDbContext).Assembly);
    }
}
