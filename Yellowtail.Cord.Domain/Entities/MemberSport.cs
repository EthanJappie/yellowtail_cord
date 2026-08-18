namespace Yellowtail.Cord.Domain.Entities;

public class MemberSport
{
    public Guid MemberId { get; set; }
    public Member? Member { get; set; }

    public Guid SportId { get; set; }
    public Sport? Sport { get; set; }
}
