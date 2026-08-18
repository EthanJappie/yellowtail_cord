using Yellowtail.Cord.Application.Common.Interfaces;

namespace Yellowtail.Cord.Infrastructure.Services;

public class TenantProvider : ITenantProvider
{
    private Guid? _currentTenantId;

    public Guid? CurrentTenantId => _currentTenantId;

    public void SetCurrentTenant(Guid tenantId)
    {
        _currentTenantId = tenantId;
    }
}
