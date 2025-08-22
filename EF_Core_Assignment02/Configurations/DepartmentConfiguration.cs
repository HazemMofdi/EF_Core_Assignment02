using EF_Core_Assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Assignment02.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey("ID");

            builder.Property("Name")
                   .HasColumnName("Department Name")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

            builder.HasIndex("Name")
                   .IsUnique();

            builder.Property(d => d.HiringDate)
                   .HasColumnType("date")
                   .IsRequired();

            builder.ToTable(t => 
            { 
                t.HasCheckConstraint("CHK_Department_HiringDate", "[HiringDate] <= GETDATE()"); 
            });
        }
    }
}
