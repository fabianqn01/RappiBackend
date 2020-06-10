using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rappi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rappi.Infrastructure.Configurations
{
    public class TypeIdentificaitionConfiguration : IEntityTypeConfiguration<TypeIdentificaition>
    {
        public void Configure(EntityTypeBuilder<TypeIdentificaition> builder)
        {
            builder.HasKey(e => e.IdTypeIdentification);

            builder.ToTable("typeIdentificaition");

            builder.Property(e => e.IdTypeIdentification)
                .HasColumnName("idTypeIdentification")
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }
}
