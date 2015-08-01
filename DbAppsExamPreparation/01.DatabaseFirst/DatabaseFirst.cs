using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DatabaseFirst
{
    class DatabaseFirst
    {
        static void Main()
        {
            var context = new FootballEntities();
            var teamNames = context.Teams.Select(t => t.TeamName);
            foreach (var teamName in teamNames)
            {
                Console.WriteLine(teamName);
            }
        }
    }
}
