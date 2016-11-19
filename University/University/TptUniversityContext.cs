namespace University
{
    using Models;
    using System.Data.Entity;

    public class TptUniversityContext : DbContext
    {

        public TptUniversityContext()
            : base("name=TptUniversityContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            base.OnModelCreating(modelBuilder);
        }


    }
}
