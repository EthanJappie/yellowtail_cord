using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly CordDbContext _context;

    public TenantRepository(CordDbContext context)
    {
        _context = context;
    }

    public async Task<Tenant?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Tenants.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<Tenant?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Tenants.FirstOrDefaultAsync(t => t.Name == name, cancellationToken);
    }

    public IQueryable<Tenant> GetAll()
    {
        return _context.Tenants.AsQueryable();
    }

    public void Add(Tenant tenant)
    {
        _context.Tenants.Add(tenant);
    }

    public void Remove(Tenant tenant)
    {
        _context.Tenants.Remove(tenant);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
