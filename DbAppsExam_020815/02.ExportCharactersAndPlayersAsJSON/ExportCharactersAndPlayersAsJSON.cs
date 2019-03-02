using _01.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _02.ExportCharactersAndPlayersAsJSON
{
    class ExportCharactersAndPlayersAsJSON
    {
        static void Main()
        {
            // exporting all characters along with the names of the players who played them
            var context = new DiabloEntities();
            var characters = context.Characters
                .OrderBy(ch => ch.Name)
                .Select(ch => new
            {
                name = ch.Name,
                playedBy = ch.UsersGames.Select(u => u.Users.Username)

            }).ToList();

            var json = new JavaScriptSerializer().Serialize(characters);
            //System.IO.File.WriteAllText("../../characters.json", json);

            Console.WriteLine(json);
        }
    }
}
