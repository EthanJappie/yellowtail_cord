using Yellowtail.Cord.Domain.Common;

namespace Yellowtail.Cord.Domain.Entities;

public class Member : BaseAuditableEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant? Tenant { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; }

    public ICollection<MemberSport> MemberSports { get; set; } = new List<MemberSport>();
}
