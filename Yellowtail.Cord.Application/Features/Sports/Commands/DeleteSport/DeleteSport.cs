using MediatR;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;

namespace Yellowtail.Cord.Application.Features.Sports.Commands.DeleteSport;

public record DeleteSportCommand(Guid Id) : IRequest<bool>;

public class DeleteSportCommandHandler : IRequestHandler<DeleteSportCommand, bool>
{
    private readonly ISportRepository _sportRepository;
    private readonly IMemberRepository _memberRepository;

    public DeleteSportCommandHandler(ISportRepository sportRepository, IMemberRepository memberRepository)
    {
        _sportRepository = sportRepository;
        _memberRepository = memberRepository;
    }

    public async Task<bool> Handle(DeleteSportCommand request, CancellationToken cancellationToken)
    {
        var sport = await _sportRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sport == null)
            return false;

        // Unlink members from the sport
        var membersWithSport = await _memberRepository.GetAll()
            .Include(m => m.MemberSports)
            .Where(m => m.MemberSports.Any(ms => ms.SportId == request.Id))
            .ToListAsync(cancellationToken);

        foreach (var member in membersWithSport)
        {
            var msToRemove = member.MemberSports.FirstOrDefault(ms => ms.SportId == request.Id);
            if (msToRemove != null)
            {
                member.MemberSports.Remove(msToRemove);
            }
        }

        _sportRepository.Remove(sport);
        
        await _sportRepository.SaveChangesAsync(cancellationToken);
        // Note: member updates will be saved simultaneously since they share the DbContext
        
        return true;
    }
}
