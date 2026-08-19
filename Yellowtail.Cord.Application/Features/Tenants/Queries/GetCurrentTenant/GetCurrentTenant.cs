using MediatR;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Application.Common.Models;

namespace Yellowtail.Cord.Application.Features.Tenants.Queries.GetCurrentTenant;

public record GetCurrentTenantQuery() : IRequest<TenantDto?>;

public class GetCurrentTenantQueryHandler : IRequestHandler<GetCurrentTenantQuery, TenantDto?>
{
    private readonly ITenantRepository _repository;
    private readonly ITenantProvider _tenantProvider;

    public GetCurrentTenantQueryHandler(ITenantRepository repository, ITenantProvider tenantProvider)
    {
        _repository = repository;
        _tenantProvider = tenantProvider;
    }

    public async Task<TenantDto?> Handle(GetCurrentTenantQuery request, CancellationToken cancellationToken)
    {
        if (_tenantProvider.CurrentTenantId == null)
            return null;

        var tenant = await _repository.GetAll()
            .AsNoTracking()
            .Where(t => t.Id == _tenantProvider.CurrentTenantId)
            .Select(t => new TenantDto(t.Id, t.Name, t.IsActive, t.ModifiedDate))
            .FirstOrDefaultAsync(cancellationToken);

        return tenant;
    }
}
