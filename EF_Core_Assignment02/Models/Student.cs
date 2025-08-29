using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string FName { get; set; }

        [Required, MaxLength(50)]
        public string LName { get; set; }

        [MaxLength(150)]
        public string? Address { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int Dept_ID { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Stud_Course> Stud_Courses { get; set; }
    }
}
