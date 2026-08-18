using Yellowtail.Cord.Domain.Common;

namespace Yellowtail.Cord.Domain.Entities;

public class Tenant : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public ICollection<Member> Members { get; set; } = new List<Member>();
}
