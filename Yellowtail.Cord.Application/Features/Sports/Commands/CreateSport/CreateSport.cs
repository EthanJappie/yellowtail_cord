using FluentValidation;
using MediatR;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Application.Features.Sports.Commands.CreateSport;

public record CreateSportCommand(string Name, string Description) : IRequest<Guid>;

public class CreateSportCommandValidator : AbstractValidator<CreateSportCommand>
{
    public CreateSportCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
    }
}

public class CreateSportCommandHandler : IRequestHandler<CreateSportCommand, Guid>
{
    private readonly ISportRepository _repository;

    public CreateSportCommandHandler(ISportRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateSportCommand request, CancellationToken cancellationToken)
    {
        var sport = new Sport
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        _repository.Add(sport);
        await _repository.SaveChangesAsync(cancellationToken);

        return sport.Id;
    }
}
