using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class NewsAnnouncementConfiguration : IEntityTypeConfiguration<NewsAnnouncement> {
    public void Configure(EntityTypeBuilder<NewsAnnouncement> builder) {
        builder.ToTable("NewsAnnouncement");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .HasColumnName("id");

        builder.Property(e => e.Description).HasColumnName("description");

        builder.Property(e => e.Image).HasColumnName("image");

        builder.Property(e => e.NewsAnnouncementCategoryId).HasColumnName("news_announcement_category_id");

        builder.Property(e => e.Title).HasColumnName("title");

        builder.HasOne(d => d.File)
            .WithMany(p=>p.NewsAnnouncements)
            .HasForeignKey(d => d.Image)
            .HasConstraintName("newsAnnouncement_fk_1");

        builder.HasOne(d => d.NewsAnnouncementCategory)
            .WithMany(p => p.NewsAnnouncements)
            .HasForeignKey(d => d.NewsAnnouncementCategoryId)
            .HasConstraintName("newsAnnouncement_fk");

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
