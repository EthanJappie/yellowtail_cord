using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly CordDbContext _context;

    public MemberRepository(CordDbContext context)
    {
        _context = context;
    }

    public async Task<Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Members.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public IQueryable<Member> GetAll()
    {
        return _context.Members.AsQueryable();
    }

    public void Add(Member member)
    {
        _context.Members.Add(member);
    }

    public void Remove(Member member)
    {
        _context.Members.Remove(member);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
