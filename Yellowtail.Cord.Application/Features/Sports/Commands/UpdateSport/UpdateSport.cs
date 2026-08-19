using FluentValidation;
using MediatR;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;

namespace Yellowtail.Cord.Application.Features.Sports.Commands.UpdateSport;

public record UpdateSportCommand(Guid Id, string Name, string Description) : IRequest<bool>;

public class UpdateSportCommandValidator : AbstractValidator<UpdateSportCommand>
{
    public UpdateSportCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
    }
}

public class UpdateSportCommandHandler : IRequestHandler<UpdateSportCommand, bool>
{
    private readonly ISportRepository _repository;

    public UpdateSportCommandHandler(ISportRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateSportCommand request, CancellationToken cancellationToken)
    {
        var sport = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (sport == null)
            return false;

        sport.Name = request.Name;
        sport.Description = request.Description;

        await _repository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
