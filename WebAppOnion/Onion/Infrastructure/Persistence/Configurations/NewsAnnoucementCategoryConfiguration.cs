using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class NewsAnnouncementCategoryConfiguration : IEntityTypeConfiguration<NewsAnnouncementCategory> {
    public void Configure(EntityTypeBuilder<NewsAnnouncementCategory> builder) {

        builder.ToTable("NewsAnnouncementCategory");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .HasColumnName("id");

        builder.Property(e => e.Name).HasColumnName("name");

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
