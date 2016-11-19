using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string NameDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
