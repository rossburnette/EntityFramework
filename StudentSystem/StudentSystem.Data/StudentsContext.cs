namespace StudentSystem.Data
{
    using SchoolSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentsContext : DbContext
    {
       
        public StudentsContext()
            : base("name=StudentsContext")
        {
        }

        public IDbSet<Student> Student  { get; set; }

        public IDbSet<Courses> Courses { get; set; }

        public IDbSet<Homeworks> Homeworks { get; set; }

        public IDbSet<Resources> Resources { get; set; }

        public IDbSet<Licence> Licences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Courses>(student => student.Courses)
                .WithMany(course => course.Students)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("StudentId");
                    configuration.MapRightKey("CourseId");
                    configuration.ToTable("StudentCourses");
                });
            base.OnModelCreating(modelBuilder);
        }

    }


}