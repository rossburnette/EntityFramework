namespace PeopleProject
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PeopleContext : DbContext
    {
        
        public PeopleContext()
            : base("name=PeopleContext")
        {
        }

        public IDbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(person => person.FirstName);
            modelBuilder.Entity<Person>().Property(person => person.FirstName).HasMaxLength(40);
            modelBuilder.Entity<Person>().ToTable("People");
            base.OnModelCreating(modelBuilder);
        }

    }

   
}