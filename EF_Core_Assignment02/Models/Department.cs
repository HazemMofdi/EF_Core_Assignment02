using EF_Core_Assignment02.DataAccess;
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
    public class Department
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public DateOnly HiringDate { get; set; }

        #region Manage Relationship
        [ForeignKey("DepartmentManager")]
        [InverseProperty("ManagedDepartment")]
        public int? DepartmentManager_ID { get; set; }
        public virtual Instructor DepartmentManager { get; set; } 
        #endregion

        [InverseProperty("Department")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
