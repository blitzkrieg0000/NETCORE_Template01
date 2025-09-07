using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CooperativeConfiguration : IEntityTypeConfiguration<Cooperative> {
    public void Configure(EntityTypeBuilder<Cooperative> builder) {
        builder.ToTable("Cooperative");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.Property(e => e.CooperativeCategoryId).HasColumnName("cooperative_category_id");

        builder.Property(e => e.Location).HasColumnName("location");

        builder.Property(e => e.Name).HasColumnName("name");

        builder.Property(e => e.Phone).HasColumnName("phone");

        builder.Property(e => e.Url).HasColumnName("url");

        builder.HasOne(d => d.CooperativeCategory)
            .WithMany(p => p.Cooperatives)
            .HasForeignKey(d => d.CooperativeCategoryId)
            .HasConstraintName("cooperative_fk");

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
