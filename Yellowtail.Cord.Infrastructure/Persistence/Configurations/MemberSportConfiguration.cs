using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence.Configurations;

public class MemberSportConfiguration : IEntityTypeConfiguration<MemberSport>
{
    public void Configure(EntityTypeBuilder<MemberSport> builder)
    {
        builder.ToTable("MemberSports");

        builder.HasKey(ms => new { ms.MemberId, ms.SportId });

        builder.HasOne(ms => ms.Member)
            .WithMany(m => m.MemberSports)
            .HasForeignKey(ms => ms.MemberId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ms => ms.Sport)
            .WithMany(s => s.MemberSports)
            .HasForeignKey(ms => ms.SportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
