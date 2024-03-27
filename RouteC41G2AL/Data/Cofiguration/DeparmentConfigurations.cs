using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteC41G2DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteC41G2DAL.Data.Cofiguration
{
    internal class DeparmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Fluent APIS for "Department" Domain

            builder.Property(D =>D.Id).UseIdentityColumn(10,10);

            builder.HasMany(D => D.Employees)
                .WithOne(E => E.Department)
                .HasForeignKey(E => E.Department)
                .OnDelete(  DeleteBehavior.Cascade);







          //  builder.Property(D => D.Code).HasColumnType("Varchar").HasMaxLength(50).IsRequired();
          //  builder.Property(D => D.Name).HasColumnType("Varchar").HasMaxLength(50).IsRequired();



        }
    }
}
