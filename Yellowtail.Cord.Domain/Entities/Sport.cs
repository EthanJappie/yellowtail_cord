using Yellowtail.Cord.Domain.Common;

namespace Yellowtail.Cord.Domain.Entities;

public class Sport : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<MemberSport> MemberSports { get; set; } = new List<MemberSport>();
}
