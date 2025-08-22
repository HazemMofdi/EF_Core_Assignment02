using EF_Core_Assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Assignment02.Configurations
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey("ID");

            builder.Property("Name")
                   .HasColumnName("Instructor Name")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

            builder.Property("Salary")
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property("Address")
                   .HasColumnType("nvarchar(150)");


            builder.Property("HourRateBouns")
                   .HasColumnType("decimal(10,2)")
                   .HasDefaultValue(0);


            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CHK_Instructor_Salary", "[Salary] > 0");
                t.HasCheckConstraint("CHK_Instructor_HourRateBouns", "[HourRateBouns] >= 0");
            });
        }
    }
}
