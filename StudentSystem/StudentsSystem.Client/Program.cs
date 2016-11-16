using StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsContext context = new StudentsContext();

            AllStudentsAndHomeworkSubmissions(context);

            Console.WriteLine();

            AllCoursesWithCorrespondingResources(context);

            Console.WriteLine();

            AllCoursesWithMoreThan5Resources(context);

            Console.WriteLine();

            AllCoursesActiveOnGivenDate(context, DateTime.Today);

            Console.WriteLine();

            AllStudentsWithCoursesInfo(context);
        }

        private static void AllStudentsWithCoursesInfo(StudentsContext context)
        {
            var students = context.Student
                 .OrderByDescending(student => student.Courses.Sum(course => course.Price))
                 .ThenBy(student => student.Name);

            foreach (var student in students)
            {
                if(student.Courses.Count != 0)
                {
                    Console.WriteLine($"{student.Name} {student.Courses.Count} {student.Courses.Sum(course => course.Price)} {student.Courses.Average(course => course.Price)}");
                }
            }
        }

        private static void AllCoursesActiveOnGivenDate(StudentsContext context, DateTime activeDate)
        {
            var courses = context.Courses
                .Where(couse => couse.StartDate <= activeDate && couse.EndDate >= activeDate)
                .OrderBy(course => course.Students.Count)
                .Select(course => new
                {
                    course.Name,
                    course.StartDate,
                    course.EndDate,
                    Duration = SqlFunctions.DateDiff("day", course.StartDate, course.EndDate),
                    StudentsCount = course.Students.Count
                });

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.StartDate} {course.EndDate} {course.Duration} - {course.StudentsCount}");
            }
        }

        private static void AllCoursesWithMoreThan5Resources(StudentsContext context)
        {
            var courses =
                context.Courses.Where(course => course.Resources.Count > 5)
                .OrderByDescending(course => course.Resources.Count)
                .ThenByDescending(course => course.StartDate);
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} - {course.Resources.Count}");
            }

        }

        private static void AllCoursesWithCorrespondingResources(StudentsContext context)
        {
            var courses = context.Courses.OrderBy(course => course.StartDate).ThenByDescending(course => course.EndDate);
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.Description}");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"{resource.Name} {resource.Type} {resource.URL}");
                }
            }

          
        }

        private static void AllStudentsAndHomeworkSubmissions(StudentsContext context)
        {
            var students = context.Student.Where(student => student.Homeworks.ToList().Count > 0);
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
                foreach (var homeworks in student.Homeworks)
                {
                    Console.WriteLine($"--{homeworks.Content} - {homeworks.ContentType}");
                }
            }
        }
    }
}
