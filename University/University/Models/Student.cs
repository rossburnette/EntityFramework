using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    //[Table("Students")]  --Tpt
    public class Student : Person
    {
        public double AverageGrade { get; set; }

        public string Attendance { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
