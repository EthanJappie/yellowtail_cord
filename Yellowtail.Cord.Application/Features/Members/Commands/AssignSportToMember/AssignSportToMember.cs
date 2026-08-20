using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Application.Features.Members.Commands.AssignSportToMember;

public record AssignSportToMemberCommand(Guid MemberId, Guid SportId) : IRequest<bool>;

public class AssignSportToMemberCommandValidator : AbstractValidator<AssignSportToMemberCommand>
{
    public AssignSportToMemberCommandValidator()
    {
        RuleFor(x => x.MemberId).NotEmpty();
        RuleFor(x => x.SportId).NotEmpty();
    }
}

public class AssignSportToMemberCommandHandler : IRequestHandler<AssignSportToMemberCommand, bool>
{
    private readonly IMemberRepository _memberRepository;
    private readonly ISportRepository _sportRepository;

    public AssignSportToMemberCommandHandler(IMemberRepository memberRepository, ISportRepository sportRepository)
    {
        _memberRepository = memberRepository;
        _sportRepository = sportRepository;
    }

    public async Task<bool> Handle(AssignSportToMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetAll().Include(m => m.MemberSports)
            .FirstOrDefaultAsync(m => m.Id == request.MemberId, cancellationToken);
            
        if (member == null)
            return false;

        var sport = await _sportRepository.GetByIdAsync(request.SportId, cancellationToken);
        if (sport == null)
            return false;

        if (member.MemberSports.Any(ms => ms.SportId == request.SportId))
            return true; // Already assigned

        member.MemberSports.Add(new MemberSport
        {
            MemberId = request.MemberId,
            SportId = request.SportId
        });

        await _memberRepository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
