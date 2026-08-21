using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Application.Common.Models;

namespace Yellowtail.Cord.Application.Features.Admin.Queries.GetGlobalMembers;

public record GetGlobalMembersQuery(int Page = 1, int PageSize = 20) : IRequest<PaginatedList<MemberDto>>;

public class GetGlobalMembersQueryValidator : AbstractValidator<GetGlobalMembersQuery>
{
    public GetGlobalMembersQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
    }
}

public class GetGlobalMembersQueryHandler : IRequestHandler<GetGlobalMembersQuery, PaginatedList<MemberDto>>
{
    private readonly IMemberRepository _repository;

    public GetGlobalMembersQueryHandler(IMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedList<MemberDto>> Handle(GetGlobalMembersQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetAll()
            .AsNoTracking()
            .Select(m => new MemberDto(
                m.Id, m.TenantId, m.FirstName, m.LastName, m.PhotoUrl, m.ModifiedDate,
                m.MemberSports.Select(ms => new SportDto(ms.Sport!.Id, ms.Sport.Name, ms.Sport.Description, ms.Sport.ModifiedDate)).ToList()));

        return await PaginatedList<MemberDto>.CreateAsync(query, request.Page, request.PageSize, cancellationToken);
    }
}
