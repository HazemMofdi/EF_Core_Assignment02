using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Models
{
    public class Inst_Course
    {
        public int? Evaluate { get; set; }


        [ForeignKey("Instructor")]
        public int Inst_ID { get; set; }
        public Instructor Instructor { get; set; }


        [ForeignKey("Course")]
        public int Course_ID { get; set; }
        public Course Course { get; set; }
    }
}
