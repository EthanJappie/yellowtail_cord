using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence;

public class CordDbContext : DbContext
{
    private readonly ITenantProvider? _tenantProvider;

    public CordDbContext(
        DbContextOptions<CordDbContext> options,
        ITenantProvider? tenantProvider = null)
        : base(options)
    {
        _tenantProvider = tenantProvider;
    }

    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<Sport> Sports => Set<Sport>();
    public DbSet<MemberSport> MemberSports => Set<MemberSport>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CordDbContext).Assembly);

        modelBuilder.Entity<Member>().HasQueryFilter(m =>
            _tenantProvider == null ||
            _tenantProvider.CurrentTenantId == null ||
            m.TenantId == _tenantProvider.CurrentTenantId);

        modelBuilder.Entity<MemberSport>().HasQueryFilter(ms =>
            _tenantProvider == null ||
            _tenantProvider.CurrentTenantId == null ||
            (ms.Member != null && ms.Member.TenantId == _tenantProvider.CurrentTenantId));
    }
}
