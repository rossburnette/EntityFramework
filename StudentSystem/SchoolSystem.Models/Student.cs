using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Courses>();
            this.Homeworks = new HashSet<Homeworks>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }

        public virtual ICollection<Homeworks> Homeworks { get; set; }
    }
}
