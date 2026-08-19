using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Application.Common.Interfaces.Repositories;

public interface ITenantRepository
{
    Task<Tenant?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Tenant?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    IQueryable<Tenant> GetAll();
    void Add(Tenant tenant);
    void Remove(Tenant tenant);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public interface IMemberRepository
{
    Task<Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    IQueryable<Member> GetAll();
    IQueryable<Member> GetAllGlobal(); // Bypasses tenant filter
    void Add(Member member);
    void Remove(Member member);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public interface ISportRepository
{
    Task<Sport?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    IQueryable<Sport> GetAll();
    void Add(Sport sport);
    void Remove(Sport sport);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
