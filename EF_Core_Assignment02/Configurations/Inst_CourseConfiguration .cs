using EF_Core_Assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Assignment02.Configurations
{
    public class Inst_CourseConfiguration : IEntityTypeConfiguration<Inst_Course>
    {
        public void Configure(EntityTypeBuilder<Inst_Course> builder)
        {
            builder.HasKey(ic => new { ic.Inst_ID , ic.Course_ID });


            builder.HasOne(ic => ic.Instructor)
                   .WithMany(i => i.Inst_Courses)
                   .HasForeignKey(ic => ic.Inst_ID);


            builder.HasOne(ic => ic.Course)
                   .WithMany(c => c.Inst_Courses)
                   .HasForeignKey(ic => ic.Course_ID);


            builder.ToTable(t =>
                t.HasCheckConstraint("CHK_CourseInst_Evaluate", "[Evaluate] BETWEEN 1 AND 10"));
        }
    }
}
