using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
   public  class Licence
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Resources Resource { get; set; }
    }
}
