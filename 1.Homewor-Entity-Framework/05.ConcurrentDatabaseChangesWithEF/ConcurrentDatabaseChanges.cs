using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DbContext_SoftUniDatabase
{
    class ConcurrentDatabaseChanges
    {
        public static void ConcurrentEmployeeNameChanges(string firstConcurrent, string secondConcurrent)
        {
            var context1 = new SoftUniEntities();

            var employee1 = context1.Employees.Find(1);
            employee1.FirstName = firstConcurrent;

            var context2 = new SoftUniEntities();

            var employee2 = context2.Employees.Find(1);
            employee2.FirstName = secondConcurrent;

            context1.SaveChanges();
            context2.SaveChanges(); //It will be executed
        }
    }
}
