using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Models
{
    public class Stud_Course
    {
        public int? Grade { get; set; }


        [ForeignKey("Student")]
        public int Stud_ID { get; set; }
        public virtual Student Student { get; set; }


        [ForeignKey("Course")]
        public int Course_ID { get; set; }
        public virtual Course Course { get; set; }
    }
}
