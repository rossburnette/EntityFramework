namespace University
{
    using Models;
    using System.Data.Entity;

    public class TphUniversityContext : DbContext
    {
        
        public TphUniversityContext()
            : base("name=TphUniversityContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

    }

   
}