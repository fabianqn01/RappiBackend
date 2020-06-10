using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rappi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rappi.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
           
                builder.HasKey(e => e.IdEmployee);

                builder.ToTable("employee");

                builder.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.IdSubArea).HasColumnName("idSubArea");

                builder.Property(e => e.IdTypeIdentification).HasColumnName("idTypeIdentification");

                builder.Property(e => e.LastChange)
                    .HasColumnName("lastChange")
                    .HasColumnType("datetime");

                builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.NumberDocument)
                    .IsRequired()
                    .HasColumnName("numberDocument")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                builder.HasOne(d => d.IdSubAreaNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdSubArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_subArea");

                builder.HasOne(d => d.IdTypeIdentificationNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdTypeIdentification)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_typeIdentificaition");
           
        }
    }
}
