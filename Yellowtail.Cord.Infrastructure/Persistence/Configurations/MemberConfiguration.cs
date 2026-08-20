using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yellowtail.Cord.Domain.Entities;

namespace Yellowtail.Cord.Infrastructure.Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.TenantId)
            .IsRequired();

        builder.Property(m => m.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.PhotoUrl)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(m => m.ModifiedDate)
            .IsRequired();

        builder.Property(m => m.ModifiedBy)
            .IsRequired();

        builder.HasIndex(m => m.TenantId);

        builder.HasOne(m => m.Tenant)
            .WithMany(t => t.Members)
            .HasForeignKey(m => m.TenantId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Dummy Data Seed
        var now = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var sysUser = new Guid("00000000-0000-0000-0000-000000000001");
        
        var tenant2 = new Guid("22222222-2222-2222-2222-222222222222");
        var tenant3 = new Guid("33333333-3333-3333-3333-333333333333");
        var tenant4 = new Guid("44444444-4444-4444-4444-444444444444");

        builder.HasData(
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666661"), TenantId = tenant2, FirstName = "Alice", LastName = "Smith", ModifiedDate = now, ModifiedBy = sysUser },
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666662"), TenantId = tenant2, FirstName = "Bob", LastName = "Johnson", ModifiedDate = now, ModifiedBy = sysUser },
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666663"), TenantId = tenant2, FirstName = "Charlie", LastName = "Brown", ModifiedDate = now, ModifiedBy = sysUser },
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666664"), TenantId = tenant3, FirstName = "Diana", LastName = "Prince", ModifiedDate = now, ModifiedBy = sysUser },
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666665"), TenantId = tenant3, FirstName = "Evan", LastName = "Wright", ModifiedDate = now, ModifiedBy = sysUser },
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666666"), TenantId = tenant3, FirstName = "Fiona", LastName = "Gallagher", ModifiedDate = now, ModifiedBy = sysUser },
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666667"), TenantId = tenant4, FirstName = "George", LastName = "Clark", ModifiedDate = now, ModifiedBy = sysUser },
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666668"), TenantId = tenant4, FirstName = "Hannah", LastName = "Abbott", ModifiedDate = now, ModifiedBy = sysUser },
            new Member { Id = new Guid("66666666-6666-6666-6666-666666666669"), TenantId = tenant4, FirstName = "Ian", LastName = "Malcolm", ModifiedDate = now, ModifiedBy = sysUser }
        );
    }
}
