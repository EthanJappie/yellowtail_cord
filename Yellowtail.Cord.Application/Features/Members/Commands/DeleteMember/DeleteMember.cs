using MediatR;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;

namespace Yellowtail.Cord.Application.Features.Members.Commands.DeleteMember;

public record DeleteMemberCommand(Guid Id) : IRequest<bool>;

public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, bool>
{
    private readonly IMemberRepository _repository;

    public DeleteMemberCommandHandler(IMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (member == null)
            return false;

        _repository.Remove(member);
        await _repository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
