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

        // Dummy Data Seed
        var m1 = new Guid("66666666-6666-6666-6666-666666666661");
        var m2 = new Guid("66666666-6666-6666-6666-666666666662");
        var m3 = new Guid("66666666-6666-6666-6666-666666666663");
        var m4 = new Guid("66666666-6666-6666-6666-666666666664");
        var m5 = new Guid("66666666-6666-6666-6666-666666666665");
        var m6 = new Guid("66666666-6666-6666-6666-666666666666");
        var m7 = new Guid("66666666-6666-6666-6666-666666666667");
        var m8 = new Guid("66666666-6666-6666-6666-666666666668");
        var m9 = new Guid("66666666-6666-6666-6666-666666666669");

        var s1 = new Guid("55555555-5555-5555-5555-555555555551"); // Soccer
        var s2 = new Guid("55555555-5555-5555-5555-555555555552"); // Basketball
        var s3 = new Guid("55555555-5555-5555-5555-555555555553"); // Tennis
        var s4 = new Guid("55555555-5555-5555-5555-555555555554"); // Swimming
        var s5 = new Guid("55555555-5555-5555-5555-555555555555"); // Athletics
        var s6 = new Guid("55555555-5555-5555-5555-555555555556"); // Cycling
        var s7 = new Guid("55555555-5555-5555-5555-555555555557"); // Boxing
        var s8 = new Guid("55555555-5555-5555-5555-555555555558"); // Gymnastics
        var s9 = new Guid("55555555-5555-5555-5555-555555555559"); // Volleyball
        var s10 = new Guid("55555555-5555-5555-5555-55555555555a"); // Rugby

        builder.HasData(
            new MemberSport { MemberId = m1, SportId = s1 },
            new MemberSport { MemberId = m2, SportId = s2 },
            new MemberSport { MemberId = m2, SportId = s3 },
            new MemberSport { MemberId = m3, SportId = s4 },
            new MemberSport { MemberId = m4, SportId = s5 },
            new MemberSport { MemberId = m4, SportId = s6 },
            new MemberSport { MemberId = m5, SportId = s7 },
            new MemberSport { MemberId = m6, SportId = s8 },
            new MemberSport { MemberId = m6, SportId = s9 },
            new MemberSport { MemberId = m7, SportId = s10 },
            new MemberSport { MemberId = m8, SportId = s1 },
            new MemberSport { MemberId = m8, SportId = s4 },
            new MemberSport { MemberId = m9, SportId = s2 },
            new MemberSport { MemberId = m9, SportId = s6 }
        );
    }
}
