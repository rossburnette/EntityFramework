using PeopleProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleContext context = new PeopleContext();
            try
            {
                Person person = new Person();
                person.FirstName = "ivaylo";
                context.People.Add(person);
                context.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                foreach (var dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (var dbValidationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(dbValidationError.ErrorMessage);
                    }
                }
            }


            
        }
    }
}
