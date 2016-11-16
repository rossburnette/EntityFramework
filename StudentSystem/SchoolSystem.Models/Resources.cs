using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public enum ResourceType
    {
        video, presentation, document, other
    };

    public class Resources
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType Type { get; set; }

        public string URL { get; set; }

        public virtual Courses Course { get; set; }

        public virtual ICollection<Licence> Licences { get; set; }

    }
}
