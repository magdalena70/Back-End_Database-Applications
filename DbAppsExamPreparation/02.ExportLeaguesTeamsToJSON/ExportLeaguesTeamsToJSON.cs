using _01.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _02.ExportLeaguesTeamsToJSON
{
    class ExportLeaguesTeamsToJSON
    {
        static void Main()
        {
            var context = new FootballEntities();
            var leagues = context.Leagues.OrderBy(l => l.LeagueName).Select(l => new 
                { 
                    Name = l.LeagueName,
                    LeagueTeams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName) 
                }).ToList();

            var json = new JavaScriptSerializer().Serialize(leagues);
            System.IO.File.WriteAllText("../../leagues-and-teams.json", json);

            //Console.WriteLine(json);

        }
    }
}
