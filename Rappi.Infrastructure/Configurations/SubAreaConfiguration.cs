using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rappi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rappi.Infrastructure.Configurations
{
    public class SubAreaConfiguration : IEntityTypeConfiguration<SubArea>
    {
        public void Configure(EntityTypeBuilder<SubArea> builder)
        {
            builder.HasKey(e => e.IdSubArea);

            builder.ToTable("subArea");

            builder.Property(e => e.IdSubArea)
                .HasColumnName("idSubArea")
                .ValueGeneratedNever();

            builder.Property(e => e.Active).HasColumnName("active");

            builder.Property(e => e.IdArea).HasColumnName("idArea");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdAreaNavigation)
                .WithMany(p => p.SubArea)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subArea_area");
        }
    }
}
