using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DbContext_SoftUniDatabase
{
    //Problem 4 -

    //Find all employees who have projects with start date in the year 2002. 
    //Select only their first name. Solve this task by using both LINQ query 
    //and native SQL query through the context. 

    public class NativeSQL_Query
    {
        public static void PrintNamesWithNativeQuery()
        {
            var context = new SoftUniEntities();
            var employee = context.Database.SqlQuery<Employee>(
                "SELECT FirstName FROM Employees e" +
                "WHERE EXISTS(SELECT p.ProjectID FROM Projects p " + 
                    "LEFT JOIN EmployeesProjects ep " +
                    "ON p.ProjectID = ep.ProjectID " +
                    "LEFT JOIN Employees em " +
                    "ON ep.EmployeeID = em.EmployeeID " +
                    "WHERE em.EmployeeID = e.EmployeeID " + 
                    "AND YEAR(p.StartDate) = 2002)")
                    .ToList();

            Console.WriteLine(string.Join(" | ", employee));

        }

        public static void PrintNamesWithLinqQuery()
        {
            var context = new SoftUniEntities();
            var employee = context.Employees
            .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
            .Select(e => e.FirstName);
            List<string> employees = employee.ToList();

            Console.WriteLine(string.Join(" | ", employees));
        }
    }
}
