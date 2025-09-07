using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;


public class GrantSupportConfiguration : IEntityTypeConfiguration<GrantSupport> {
    public void Configure(EntityTypeBuilder<GrantSupport> builder) {
        builder.ToTable("GrantSupport");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.Property(e => e.Description).HasColumnName("description");

        builder.Property(e => e.GrantSupportCategoryId).HasColumnName("grant_support_category_id");

        builder.Property(e => e.Image).HasColumnName("image");

        builder.Property(e => e.Title).HasColumnName("title");

        builder.HasOne(d => d.GrantSupportCategory)
            .WithMany(p => p.GrantSupports)
            .HasForeignKey(d => d.GrantSupportCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("grantsupport_fk");

        builder.HasOne(d => d.File)
            .WithMany(p => p.GrantSupports)
            .HasForeignKey(d => d.Image)
            .HasConstraintName("grantsupport_fk_1");

        builder.Property(e => e.ModifiedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("modified_time");

        builder.Property(e => e.CreatedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_time")
            .HasDefaultValueSql("((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)");

        builder.Property(e => e.DeletedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("deleted_time");
    }
}
