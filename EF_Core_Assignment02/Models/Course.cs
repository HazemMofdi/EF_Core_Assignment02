using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int Duration { get; set; }

        [ForeignKey("Topic")]
        public int Topic_ID { get; set; }
        public Topic Topic { get; set; }

        public ICollection<Stud_Course> Stud_Courses { get; set; }
        public ICollection<Inst_Course> Inst_Courses { get; set; }
    }
}
