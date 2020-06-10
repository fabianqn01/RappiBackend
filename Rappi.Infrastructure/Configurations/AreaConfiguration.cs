using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rappi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rappi.Infrastructure.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(e => e.IdArea);

            builder.ToTable("area");

            builder.Property(e => e.IdArea)
                .HasColumnName("idArea")
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
