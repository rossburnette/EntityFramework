using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{

   // [Table("Teacher")] -- Tpt
    public class Teacher : Person
    {
        [Required]
        public string Email { get; set; }

        public decimal Salary { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
