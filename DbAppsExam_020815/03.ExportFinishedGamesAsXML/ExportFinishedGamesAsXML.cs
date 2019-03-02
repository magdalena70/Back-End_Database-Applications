using _01.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03.ExportFinishedGamesAsXML
{
    class ExportFinishedGamesAsXML
    {
        static void Main()
        {
            // exporting all finished games and their players in a XML file
            var context = new DiabloEntities();
            var gamesAndPlayers = context.Games
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Duration)
                .Select(g => new
            {
                GameName = g.Name,
                GameDuration = g.Duration,
                PlayersInGames = g.UsersGames.Select(u => new 
                {
                    UserUsername = u.Users.Username,
                    UserIpAddress = u.Users.IpAddress
                })

            }).ToList();

            XElement games = new XElement("games");
            foreach (var game in gamesAndPlayers)
            {
                XElement gameXml = new XElement("game",
                    new XAttribute("name", game.GameName));
                XElement users = new XElement("users");
               
                foreach (var user in game.PlayersInGames)
                {
                    XElement userXml = new XElement("user",
                        new XAttribute("username", user.UserUsername),
                        new XAttribute("ip-address", user.UserIpAddress));
                    //Console.WriteLine("{0}, {1}", user.UserUsername, user.UserIpAddress);
                    users.Add(userXml);
                }

                if (game.GameDuration != null)
                {
                    gameXml.Add(new XAttribute("duration", game.GameDuration));
                }

                gameXml.Add(users);
                games.Add(gameXml);
            }

            Console.WriteLine(games.ToString());
            //games.Save("../../finished-games.xml");
        }
    }
}
