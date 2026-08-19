using FluentValidation;
using MediatR;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Application.Features.Tenants.Commands.CreateTenant;

public record CreateTenantCommand(string Name) : IRequest<Guid>;

public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Guid>
{
    private readonly ITenantRepository _repository;

    public CreateTenantCommandHandler(ITenantRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = new Tenant
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsActive = true
        };

        _repository.Add(tenant);
        await _repository.SaveChangesAsync(cancellationToken);

        return tenant.Id;
    }
}
