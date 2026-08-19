using FluentValidation;
using MediatR;
using Yellowtail.Cord.Application.Common.Interfaces;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;

namespace Yellowtail.Cord.Application.Features.Tenants.Commands.UpdateTenant;

public record UpdateTenantCommand(string Name) : IRequest<bool>;

public class UpdateTenantCommandValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdateTenantCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, bool>
{
    private readonly ITenantRepository _repository;
    private readonly ITenantProvider _tenantProvider;

    public UpdateTenantCommandHandler(ITenantRepository repository, ITenantProvider tenantProvider)
    {
        _repository = repository;
        _tenantProvider = tenantProvider;
    }

    public async Task<bool> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        if (_tenantProvider.CurrentTenantId == null)
            return false;

        var tenant = await _repository.GetByIdAsync(_tenantProvider.CurrentTenantId.Value, cancellationToken);
        if (tenant == null)
            return false;

        tenant.Name = request.Name;
        await _repository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
