namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : 
        DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContex>
    {
        public Configuration()
        {
            //this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemContex";
        }

        protected override void Seed(StudentSystemContex context)
        {
            /*if (!context.Students.Any())
            {
                string[] FirstNames = { "Ivan", "Mario", "Vasil", "Gosho", "Veselin" };
                string[] LastNames = { "Petrov", "Pavlov", "Ivanov", "Monov", "Iliev" };

                Random random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var student = new Student()
                    {
                        Name = FirstNames[random.Next(0, FirstNames.Length)] +
                                " " +
                                LastNames[random.Next(0, LastNames.Length)],
                        PhoneNumber = "+359 000 000 000",
                        RegistrationDate = DateTime.Now
                    };

                    context.Students.AddOrUpdate(
                        u => u.Name,
                        student);
                    context.SaveChanges();
                }
            }

            if (!context.Courses.Any())
            {
                String[] courses = { "C#", "Databases", "Java", "PHP", "HTML", "OOP" };
                List<Student> RandomStudents = new List<Student>();

                Random random = new Random();

                for (int i = 0; i < 5; i++)
                {
                    RandomStudents.Add(context.Students.Find(random.Next(0, 10)));
                }

                for (int i = 0; i < courses.Length; i++)
                {
                    Course course = new Course()
                    {
                        Name = courses[i],
                        Students = RandomStudents,
                        Description = "Some description",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        Price = (i * 100 + i)
                    };

                    context.Courses.AddOrUpdate(
                        c => c.Name,
                        course);
                    context.SaveChanges();
                }
            }

            if (!context.Resources.Any())
            {
                string[] resources = { "github", "codecacademy", "msdn", "w3school" };
                Random random = new Random();

                for (int i = 2; i < 9; i++)
                {
                    var randCourse = context.Courses.Find(i);
                    randCourse.Resources.Add(new Resource()
                    {
                        Name = resources[random.Next(0, resources.Length)],
                        TipeOfResource = TypeOfResource.Presentation,
                        Url = "https://www.google.bg"
                    });

                    context.SaveChanges();
                }
            }

            if (!context.Homeworks.Any())
            {

                for (int i = 1; i < 10; i++)
                {
                    Student student = context.Students.Find(i);
                    Homework homework = new Homework()
                    {
                        Content = i + "_Homework",
                        SubmissionDate = DateTime.Now,
                        ContentType = ContentType.App_Zip
                    };

                    context.Homeworks.Add(homework);
                    context.SaveChanges();
                }
            }*/
        }
    }
}
