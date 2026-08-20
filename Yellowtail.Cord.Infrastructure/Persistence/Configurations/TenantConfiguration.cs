using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.IsActive)
            .IsRequired();

        builder.Property(t => t.ModifiedDate)
            .IsRequired();

        builder.Property(t => t.ModifiedBy)
            .IsRequired();

        // Dummy Data Seed
        var now = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var sysUser = new Guid("00000000-0000-0000-0000-000000000001");
        
        builder.HasData(
            new Tenant { Id = new Guid("11111111-1111-1111-1111-111111111111"), Name = "Default", IsActive = true, ModifiedDate = now, ModifiedBy = sysUser },
            new Tenant { Id = new Guid("22222222-2222-2222-2222-222222222222"), Name = "Titanium Sports Club", IsActive = true, ModifiedDate = now, ModifiedBy = sysUser },
            new Tenant { Id = new Guid("33333333-3333-3333-3333-333333333333"), Name = "Apex Athletics Club", IsActive = true, ModifiedDate = now, ModifiedBy = sysUser },
            new Tenant { Id = new Guid("44444444-4444-4444-4444-444444444444"), Name = "Quantum Fitness Club", IsActive = true, ModifiedDate = now, ModifiedBy = sysUser }
        );
    }
}
