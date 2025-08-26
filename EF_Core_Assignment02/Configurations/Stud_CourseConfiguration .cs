using EF_Core_Assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Assignment02.Configurations
{
    public class Stud_CourseConfiguration : IEntityTypeConfiguration<Stud_Course>
    {
        public void Configure(EntityTypeBuilder<Stud_Course> builder)
        {
            builder.HasKey(sc => new { sc.Stud_ID, sc.Course_ID });


            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.Stud_Courses)
                   .HasForeignKey(sc => sc.Stud_ID);


            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.Stud_Courses)
                   .HasForeignKey(sc => sc.Course_ID);


            builder.ToTable(t =>
                t.HasCheckConstraint("CHK_StudCourse_Grade", "[Grade] BETWEEN 0 AND 100"));
        }
    }
}
