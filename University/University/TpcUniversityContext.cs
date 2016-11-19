namespace University
{
    using Models;
    using System.Data.Entity;

    public class TpcUniversityContext : DbContext
    {

        public TpcUniversityContext()
            : base("name=TpcUniversityContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(person => person.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel
                .DataAnnotations.Schema.DatabaseGeneratedOption.None);

            modelBuilder.Entity<Student>().Map(configuration =>
            {
                configuration.MapInheritedProperties();
                configuration.ToTable("Students");
            });

            modelBuilder.Entity<Teacher>().Map(configuration =>
            {
                configuration.MapInheritedProperties();
                configuration.ToTable("Teachers");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}