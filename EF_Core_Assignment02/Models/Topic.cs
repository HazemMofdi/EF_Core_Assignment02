using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Models
{
    public class Topic
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
