using MediatR;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Application.Features.Tenants.Commands.DeleteTenant;

public record DeleteTenantCommand(Guid Id) : IRequest<bool>;

public class DeleteTenantCommandHandler : IRequestHandler<DeleteTenantCommand, bool>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IMemberRepository _memberRepository;

    public DeleteTenantCommandHandler(ITenantRepository tenantRepository, IMemberRepository memberRepository)
    {
        _tenantRepository = tenantRepository;
        _memberRepository = memberRepository;
    }

    public async Task<bool> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(request.Id, cancellationToken);
        if (tenant == null)
            return false;

        if (tenant.Name.Equals("Default", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Cannot delete the Default fallback tenant.");

        // Find or create default tenant
        var defaultTenant = await _tenantRepository.GetByNameAsync("Default", cancellationToken);
        if (defaultTenant == null)
        {
            defaultTenant = new Tenant
            {
                Id = Guid.NewGuid(),
                Name = "Default",
                IsActive = true
            };
            _tenantRepository.Add(defaultTenant);
            await _tenantRepository.SaveChangesAsync(cancellationToken);
        }

        // Reassign members
        var members = await _memberRepository.GetAllGlobal()
            .Where(m => m.TenantId == request.Id)
            .ToListAsync(cancellationToken);

        foreach (var member in members)
        {
            member.TenantId = defaultTenant.Id;
        }

        _tenantRepository.Remove(tenant);
        
        await _tenantRepository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
