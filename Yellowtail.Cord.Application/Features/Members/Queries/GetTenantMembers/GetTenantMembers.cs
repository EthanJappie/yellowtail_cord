using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Application.Common.Models;

namespace Yellowtail.Cord.Application.Features.Members.Queries.GetTenantMembers;

public record GetTenantMembersQuery(int Page = 1, int PageSize = 20) : IRequest<PaginatedList<MemberDto>>;

public class GetTenantMembersQueryValidator : AbstractValidator<GetTenantMembersQuery>
{
    public GetTenantMembersQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
    }
}

public class GetTenantMembersQueryHandler : IRequestHandler<GetTenantMembersQuery, PaginatedList<MemberDto>>
{
    private readonly IMemberRepository _repository;
    private readonly ITenantProvider _tenantProvider;

    public GetTenantMembersQueryHandler(IMemberRepository repository, ITenantProvider tenantProvider)
    {
        _repository = repository;
        _tenantProvider = tenantProvider;
    }

    public async Task<PaginatedList<MemberDto>> Handle(GetTenantMembersQuery request, CancellationToken cancellationToken)
    {
        var tenantId = _tenantProvider.CurrentTenantId;
        
        if (tenantId == null)
        {
            throw new ValidationException(new List<FluentValidation.Results.ValidationFailure>
            {
                new("X-Tenant-Id", "Tenant context is required to query tenant members. Please supply the X-Tenant-Id header.")
            });
        }
        
        var query = _repository.GetAll()
            .AsNoTracking()
            .Where(m => m.TenantId == tenantId)
            .Select(m => new MemberDto(
                m.Id, m.TenantId, m.FirstName, m.LastName, m.PhotoUrl, m.ModifiedDate,
                m.MemberSports.Select(ms => new SportDto(ms.Sport!.Id, ms.Sport.Name, ms.Sport.Description, ms.Sport.ModifiedDate)).ToList()));

        return await PaginatedList<MemberDto>.CreateAsync(query, request.Page, request.PageSize, cancellationToken);
    }
}
