using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public enum ContentType {application, pdf, zip }

   public class Homeworks
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public ContentType  ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public virtual Courses Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
