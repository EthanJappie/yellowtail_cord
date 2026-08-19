using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence.Repositories;

public class SportRepository : ISportRepository
{
    private readonly CordDbContext _context;

    public SportRepository(CordDbContext context)
    {
        _context = context;
    }

    public async Task<Sport?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sports.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public IQueryable<Sport> GetAll()
    {
        return _context.Sports.AsQueryable();
    }

    public void Add(Sport sport)
    {
        _context.Sports.Add(sport);
    }

    public void Remove(Sport sport)
    {
        _context.Sports.Remove(sport);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
