using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rappi.Core.Entities;
using Rappi.Infrastructure.Configurations;

namespace Rappi.Infrastructure.Data
{
    public partial class RAPPIContext : DbContext
    {
        public RAPPIContext()
        {
        }

        public RAPPIContext(DbContextOptions<RAPPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<SubArea> SubArea { get; set; }
        public virtual DbSet<TypeIdentificaition> TypeIdentificaition { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.ApplyConfiguration(new SubAreaConfiguration());

            modelBuilder.ApplyConfiguration(new TypeIdentificaitionConfiguration());
        }
    }
}
