using MediatR;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Application.Common.Models;

namespace Yellowtail.Cord.Application.Features.Members.Queries.GetMemberDetails;

public record GetMemberDetailsQuery(Guid Id) : IRequest<MemberDto?>;

public class GetMemberDetailsQueryHandler : IRequestHandler<GetMemberDetailsQuery, MemberDto?>
{
    private readonly IMemberRepository _repository;

    public GetMemberDetailsQueryHandler(IMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<MemberDto?> Handle(GetMemberDetailsQuery request, CancellationToken cancellationToken)
    {
        var member = await _repository.GetAll()
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
            .Select(m => new MemberDto(m.Id, m.TenantId, m.FirstName, m.LastName, m.PhotoUrl, m.ModifiedDate))
            .FirstOrDefaultAsync(cancellationToken);

        return member;
    }
}
