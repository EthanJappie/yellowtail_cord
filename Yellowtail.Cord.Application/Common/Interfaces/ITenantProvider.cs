namespace Yellowtail.Cord.Application.Common.Interfaces;

public interface ITenantProvider
{
    Guid? CurrentTenantId { get; }
    void SetCurrentTenant(Guid tenantId);
}
