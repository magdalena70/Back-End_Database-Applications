using NewsDB.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDB.Client
{
    class Program
    {
        static void Main()
        {
            /*var context1 = new NewsDBContext();
             var count = context.NewsItems.Count();
             Console.WriteLine(count); // create DB NewsDB and use Seed method to add news items */

            // Problem 2.Concurrent Updates (Console App) -
            ConcurrentUpdatesConsoleApp.ConcurrentUpdates();
        }
    }
}
