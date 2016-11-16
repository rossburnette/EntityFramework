using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public class Courses
    {
        public Courses()
        {
            this.Students = new HashSet<Student>();
            this.Resources = new HashSet<Resources>();
            this.Homeworks = new HashSet<Homeworks>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; }
              
        public virtual ICollection<Resources> Resources { get; set; }
               
        public virtual ICollection<Homeworks> Homeworks { get; set; }
    }
}
