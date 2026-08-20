using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence.Configurations;

public class SportConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {
        builder.ToTable("Sports");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        builder.Property(s => s.ModifiedDate)
            .IsRequired();

        builder.Property(s => s.ModifiedBy)
            .IsRequired();

        // Dummy Data Seed
        var now = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var sysUser = new Guid("00000000-0000-0000-0000-000000000001");
        
        builder.HasData(
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555551"), Name = "Soccer", Description = "Field team sport", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555552"), Name = "Basketball", Description = "Court team sport", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555553"), Name = "Tennis", Description = "Racket sport", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555554"), Name = "Swimming", Description = "Water-based racing", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555555"), Name = "Athletics", Description = "Track and field", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555556"), Name = "Cycling", Description = "Bicycle racing", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555557"), Name = "Boxing", Description = "Combat sport", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555558"), Name = "Gymnastics", Description = "Acrobatic sport", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-555555555559"), Name = "Volleyball", Description = "Court team sport", ModifiedDate = now, ModifiedBy = sysUser },
            new Sport { Id = new Guid("55555555-5555-5555-5555-55555555555a"), Name = "Rugby", Description = "Contact team sport", ModifiedDate = now, ModifiedBy = sysUser }
        );
    }
}
