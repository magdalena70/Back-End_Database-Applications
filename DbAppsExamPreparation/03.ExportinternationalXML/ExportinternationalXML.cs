using _01.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03.ExportinternationalXML
{
    class ExportinternationalXML
    {
        static void Main()
        {
            var context = new FootballEntities();
            var internationalMatches = context.InternationalMatches
                .OrderBy(im => im.MatchDate)
                .ThenBy(im => im.CountriesHome.CountryName)
                .ThenBy(im => im.CountriesAway.CountryName)
                .Select(im => new
                {
                    HomeScore = im.HomeGoals,
                    AwayScore = im.AwayGoals,
                    HomeCodeCountry = im.HomeCountryCode,
                    AwayCodecountry = im.AwayCountryCode,
                    Date = im.MatchDate,
                    HomeCountryName = im.CountriesHome.CountryName,
                    AwayCountryname = im.CountriesAway.CountryName,
                    matchleagueName = im.Leagues.LeagueName
                }).ToList();

            XElement matches = new XElement("matches");
            foreach (var match in internationalMatches)
            {
                XElement xmlMatch = new XElement("match",
                        new XElement("home-country",
                            new XAttribute("code", match.HomeCodeCountry),
                            match.HomeCountryName
                        ),
                        new XElement("away-country",
                            new XAttribute("code", match.AwayCodecountry),
                            match.AwayCountryname
                        )
                );

                if (match.matchleagueName != null)
                {
                    xmlMatch.Add(new XElement("league", match.matchleagueName));
                }

                if (match.HomeScore != null && match.AwayScore != null)
                {
                    xmlMatch.Add(new XElement("score", 
                        match.HomeScore + "-" + match.AwayScore));
                }

                if (match.Date != null)
                {
                    DateTime dateTime;
                    DateTime.TryParse(match.Date.ToString(), out dateTime);
                    if (dateTime.TimeOfDay.TotalSeconds == 0)
                    {
                        xmlMatch.Add(new XAttribute("date", dateTime.ToString("dd-MMM-yyyy")));
                    }
                    else
                    {
                        xmlMatch.Add(new XAttribute("date-time", dateTime.ToString("dd-MMM-yyyy hh:mm")));
                    }
                }

                matches.Add(xmlMatch);
            }

            Console.WriteLine(matches.ToString());
            matches.Save("../../international-matches.xml");
        }
    }
}
