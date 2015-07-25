namespace StudentSystem.Client
{
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var context = new StudentSystemContex();
             /*var count = contex.Students.Count();
             Console.WriteLine(count); // create DB StudentSystem */


            //Problem 3 -

            //1.Lists all students and their homework submissions. 
            //Select only their names and for each homework - content and content-type.
            var students = context.Students.Select(s => new
            {
                s.Name,
                Homework = s.Homeworks.Select(hw => new
                {
                    hw.Content,
                    hw.ContentType
                })
            });
            foreach (var student in students)
            {
                Console.WriteLine(student.Name + "\n Homeworks: {");
                foreach (var homework in student.Homework)
                {
                    Console.WriteLine("\t" + homework.Content + " - Type: " + homework.ContentType);
                }
                Console.WriteLine(" }");
            }

            Console.WriteLine();

            //2.List all courses with their corresponding resources. 
            //Select the course name and description and everything for each resource. 
            //Order the courses by start date (ascending), then by end date (descending).
            var courses = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
            {
                c.Name,
                c.Description,
                Resources = c.Resources
            });

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name + " - " + course.Description + "\n Resources: {");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine("\t" + resource.Name + " - Type: " + 
                        resource.TipeOfResource + " - " +
                        resource.Url);
                }
                Console.WriteLine(" }");
            }

            Console.WriteLine();

            //3.List all courses with more than 5 resources. 
            //Order them by resources count (descending), then by start date (descending). 
            //Select only the course name and the resource count.
            var coursesWithMoreThanFifeRes = context.Courses
                .Where(c => c.Resources.Count() > 5)
                .OrderByDescending(c => c.Resources.Count())
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                    {
                        c.Name,
                        ResourceCount = c.Resources.Count()
                    });

            foreach (var course in coursesWithMoreThanFifeRes)
            {
                Console.WriteLine("Course: " + course.Name +
                    " - ResorceCount =  " + course.ResourceCount);
            }

            Console.WriteLine();

            //4.List all courses which were active on a given date 
            //(choose the date depending on the data seeded to ensure there are results), 
            //and for each course count the number of students enrolled. 
            //Select the course name, start and end date, course duration 
            //(difference between end and start date) and number of students enrolled. 
            //Order the results by the number of students enrolled (in descending order), 
            //then by duration (descending).
            DateTime date = DateTime.Now;
            var activeCourses = context.Courses
                .Where(c => c.StartDate <= date && c.EndDate >= date)
                .ToList()
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    CourseDurration = (c.EndDate - c.StartDate).TotalDays,
                    EnrolledStudents = c.Students.Count
                })
                .OrderByDescending(c => c.EnrolledStudents)
                .ThenByDescending(c => c.CourseDurration);

            Console.WriteLine("Active Courses:");
            foreach (var activeCourse in activeCourses)
            {
                Console.WriteLine("{0}: ({1:dd/MM/yy} - {2:dd/MM/yy}) -> {3} days, {4} students",
                    activeCourse.Name,
                    activeCourse.StartDate,
                    activeCourse.EndDate,
                    activeCourse.CourseDurration,
                    activeCourse.EnrolledStudents);
            }

            Console.WriteLine();

            //5.For each student, calculate the number of courses he/she has enrolled in, 
            //the total price of these courses and the average price per course for the student.
            //Select the student name, number of courses, total price and average price. 
            //Order the results by total price (descending), 
            //then by number of courses (descending) and 
            //then by the student's name (ascending).
            var studentTaxes = context.Students
                .Where(s => s.Courses.Count > 0)
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Name)
                .Select(s => new
                {
                    s.Name,
                    CoursesCount = s.Courses.Count(),
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AvgPrice = s.Courses.Sum(c => c.Price) / s.Courses.Count()
                })
                .ToList();

            foreach (var st in studentTaxes)
            {
                Console.WriteLine("{0} - {1} courses, total price {2:F}, avg price {3}",
                    st.Name,
                    st.CoursesCount,
                    st.TotalPrice,
                    st.AvgPrice);
            }
        }
    }
}
