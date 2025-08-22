using EF_Core_Assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Assignment02.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey("ID");

            builder.Property("Duration")
              .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CHK_Course_Duration", "[Duration] > 0");
            });

            builder.Property("Name")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

            builder.HasIndex("Name")
                   .IsUnique();

            builder.Property("Description")
                   .HasColumnType("nvarchar(100)");

        }
    }
}
