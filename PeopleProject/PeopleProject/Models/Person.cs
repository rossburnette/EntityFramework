using PeopleProject.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject.Models
{
    [Table("PeopleInformation")]
    public class Person
    {
       
        public int Id { get; set; }

        [NameValidation]
        public string FirstName { get; set; }

        //public Account Account { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
