using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DbContext_SoftUniDatabase
{
    //Problem 3 -

    public class DatabaseSearchQueries
    {
        //1.Find all employees who have projects started in the time period 2001 - 2003 (inclusive). 
        //Select each employee's first name, last name and manager name and 
        //each of their projects' name, start date, end date.
        public static void FindEmployeeByProjectInRange()
        {
            var context = new SoftUniEntities();
            var employeesAndProjects = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFullName = e.FirstName + " " + e.LastName,
                    Projects = e.Projects.Select(p => new
                    {
                        ProjectName = p.Name,
                        p.StartDate,
                        p.EndDate
                    }),
                    ManagerFullName = e.Employee1.FirstName + " " + e.Employee1.LastName
                });

            foreach (var emp in employeesAndProjects)
            {
                Console.WriteLine(emp.EmployeeFullName + " - Manager - " + emp.ManagerFullName + "\n Projects:{");
                foreach (var project in emp.Projects)
                {
                    Console.WriteLine("\tProjectName - " + project.ProjectName
                        + " - StartDate " + project.StartDate.ToShortDateString());
                }
                Console.WriteLine(" }");
            }
        }

        //2.Find all addresses, ordered by the number of employees who live there (descending), 
        //then by town name (ascending). 
        //Take only the first 10 addresses and select their address text, town name and employee count.
        public static void FindEmployeeByAddress()
        {
            var context = new SoftUniEntities();
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                });

            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees ",
                    address.AddressText,
                    address.TownName,
                    address.EmployeeCount);
            }
        }

        //3.Get an employee by id (e.g. 147). Select only his/her first name, 
        //last name, job title and projects (only their names). 
        //The projects should be ordered by name (ascending).
        public static void FindEmployeeById(int id)
        {
            var context = new SoftUniEntities();
            var employeeById = context.Employees.Find(id);
            var employeeProject = employeeById.Projects
                .ToList().OrderBy(p => p.Name);
            Console.WriteLine("Id = {3} {0} {1} - ({2}) - Projects:",
                employeeById.FirstName,
                employeeById.LastName,
                employeeById.JobTitle,
                employeeById.EmployeeID);
            foreach (var pr in employeeProject)
            {
                Console.WriteLine(pr.Name);
            }
        }

        //4.Find all departments with more than 5 employees. 
        //Order them by employee count (ascending). 
        //Select the department name, manager name and first name, last name, hire date and job title 
        //of every employee.
        public static void FindDepartmentByEmployeeCount()
        {
            var context = new SoftUniEntities();
            var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerName = d.Employee.FirstName + " " + d.Employee.LastName,
                EmployeesCount = d.Employees.Count
            });

            foreach (var dep in departments)
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
                    dep.DepartmentName,
                    dep.ManagerName,
                    dep.EmployeesCount);
            }
        }
    }
}
