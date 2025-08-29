using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public decimal Salary { get; set; }
        [MaxLength(150)]
        public string? Address { get; set; }
        public decimal HourRateBouns { get; set; }

        #region One To Many Department Instructor
        [ForeignKey("Department")]
        [InverseProperty("Instructors")]
        public int Dept_ID { get; set; }
        public virtual Department Department { get; set; }
        #endregion

        #region Manage Relationship
        [InverseProperty("DepartmentManager")]
        public virtual Department? ManagedDepartment { get; set; } 
        #endregion

        public virtual ICollection<Inst_Course> Inst_Courses { get; set; }
    }
}
