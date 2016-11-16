namespace StudentSystem.Data.Migrations
{
    using SchoolSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.ContextKey = "StudentsSystem.Data.StudentsContext";
        }

        public object Name { get; private set; }

        protected override void Seed(StudentSystem.Data.StudentsContext context)
        {
            context.Courses.AddOrUpdate(course => course.Name, new Courses()
            {
                Name = "C#",
                Description = "some sharp",
                EndDate = new DateTime(2017, 2, 3),
                Price = 2,
                Homeworks = new List<Homeworks>()
                {
                    new Homeworks()
                    {
                        Content = "C# homework",
                        ContentType = ContentType.application,
                        SubmissionDate = DateTime.Today,
                        Student = new Student()
                        {
                            Name = "Pesho",
                            RegisteredOn = DateTime.Today,
                            PhoneNumber = "0879317180"
                        }
                    },
                    new Homeworks()
                    {
                        Content = "java homework",
                        ContentType = ContentType.pdf,
                        SubmissionDate = DateTime.Today,
                        Student = new Student()
                        {
                            Name = "Stancho",
                            RegisteredOn = DateTime.Today,
                            PhoneNumber = "0879317180"
                        }
                    }
                },
                StartDate = DateTime.Today,
                Students = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Ivo",
                            RegisteredOn = DateTime.Today,
                            PhoneNumber = "08869899899"
                        } ,
                         new Student()
                        {
                            Name = "Reni",
                            RegisteredOn = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                    },
                Resources = new List<Resources>()
                    {
                        new Resources()
                        {
                            Name = "rasa",
                            Type = ResourceType.document,
                            URL = "sadas"
                        },
                        new Resources()
                        {
                             Name = "redasdas",
                             Type = ResourceType.document,
                             URL = "fsafasf"
                        }
                    }

            });
        }
    }
}
