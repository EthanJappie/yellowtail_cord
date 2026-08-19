using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Application.Common.Models;

namespace Yellowtail.Cord.Application.Features.Admin.Queries.GetTenants;

public record GetTenantsQuery(int Page = 1, int PageSize = 20) : IRequest<PaginatedList<TenantDto>>;

public class GetTenantsQueryValidator : AbstractValidator<GetTenantsQuery>
{
    public GetTenantsQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
    }
}

public class GetTenantsQueryHandler : IRequestHandler<GetTenantsQuery, PaginatedList<TenantDto>>
{
    private readonly ITenantRepository _repository;

    public GetTenantsQueryHandler(ITenantRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedList<TenantDto>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetAll()
            .AsNoTracking()
            .Select(t => new TenantDto(t.Id, t.Name, t.IsActive, t.ModifiedDate));

        return await PaginatedList<TenantDto>.CreateAsync(query, request.Page, request.PageSize, cancellationToken);
    }
}
