
namespace _01.DbContext_SoftUniDatabase
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            //Problem 3 -

            //1.Find all employees who have projects started in the time period 2001 - 2003 (inclusive). 
            //Select each employee's first name, last name and manager name and 
            //each of their projects' name, start date, end date.
            DatabaseSearchQueries.FindEmployeeByProjectInRange();
            
            Console.WriteLine("---------------------");

            //2.Find all addresses, ordered by the number of employees who live there (descending), 
            //then by town name (ascending). 
            //Take only the first 10 addresses and select their address text, town name and employee count.
            DatabaseSearchQueries.FindEmployeeByAddress();
            
            Console.WriteLine("---------------------");

            //3.Get an employee by id (e.g. 147). Select only his/her first name, 
            //last name, job title and projects (only their names). 
            //The projects should be ordered by name (ascending).
            DatabaseSearchQueries.FindEmployeeById(147);
            
            Console.WriteLine("---------------------");

            //4.Find all departments with more than 5 employees. 
            //Order them by employee count (ascending). 
            //Select the department name, manager name and first name, last name, hire date and job title 
            //of every employee.
            DatabaseSearchQueries.FindDepartmentByEmployeeCount();

            Console.WriteLine("--------------------");

            //Problem 4 -
            var sw = new Stopwatch();
            sw.Start();

            NativeSQL_Query.PrintNamesWithLinqQuery();
            Console.WriteLine("\nNative: {0}\n\n", sw.Elapsed);

            sw.Restart();

            NativeSQL_Query.PrintNamesWithLinqQuery();
            Console.WriteLine("\n\nLINQ: {0}\n\n", sw.Elapsed);

            sw.Stop();

            Console.WriteLine("--------------------");

            //Problem 5 -
            //Open two different data contexts and perform concurrent changes on the same records 
            //in some database table.
            //Try with another name, please!

           // ConcurrentDatabaseChanges.ConcurrentEmployeeNameChanges("FirstConcurrent", "SecondConcurrent"); // SecondConcurrent
        }
    }
}
