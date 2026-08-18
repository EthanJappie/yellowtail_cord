namespace Yellowtail.Cord.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime ModifiedDate { get; set; }
    public Guid ModifiedBy { get; set; }
}
