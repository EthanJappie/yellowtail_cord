using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

    public GetTenantMembersQueryHandler(IMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedList<MemberDto>> Handle(GetTenantMembersQuery request, CancellationToken cancellationToken)
    {
        // GetAll() is tenant scoped
        var query = _repository.GetAll()
            .AsNoTracking()
            .Select(m => new MemberDto(m.Id, m.TenantId, m.FirstName, m.LastName, m.PhotoUrl, m.ModifiedDate));

        return await PaginatedList<MemberDto>.CreateAsync(query, request.Page, request.PageSize, cancellationToken);
    }
}
