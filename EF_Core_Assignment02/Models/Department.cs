using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Models
{
    internal class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateOnly HiringDate { get; set; }
    }
}
