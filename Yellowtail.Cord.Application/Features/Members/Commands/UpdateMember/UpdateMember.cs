using FluentValidation;
using MediatR;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;

namespace Yellowtail.Cord.Application.Features.Members.Commands.UpdateMember;

public record UpdateMemberCommand(Guid Id, string FirstName, string LastName, string? PhotoUrl) : IRequest<bool>;

public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
{
    public UpdateMemberCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PhotoUrl).MaximumLength(500);
    }
}

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, bool>
{
    private readonly IMemberRepository _repository;

    public UpdateMemberCommandHandler(IMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (member == null)
            return false;

        member.FirstName = request.FirstName;
        member.LastName = request.LastName;
        member.PhotoUrl = request.PhotoUrl;

        await _repository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
