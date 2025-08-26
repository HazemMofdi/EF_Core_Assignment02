using EF_Core_Assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Assignment02.Configurations
{
    internal class StudnetConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey("ID");

            builder.Property("FName")
                .HasColumnName("First Name")
                .HasColumnType("nvarchar(50)");

            builder.Property("LName")
                .HasColumnName("Last Name")
                .HasColumnType("nvarchar(50)");


            builder.Property("Address")
                .HasColumnName("Address")
                .HasColumnType("nvarchar(150)");

            builder.Property("Age")
                .HasColumnName("Student Age")
                .HasColumnType("int");

        }
    }
}
