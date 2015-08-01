using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace D0mParserExtractAllArtistsAlphabetically
{
    class D0mParserExtractAllArtistsAlphabetically
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            //Console.WriteLine(doc.OuterXml);
            var artists = doc.SelectNodes("//album/artist");
            var artistSortedSet = new SortedSet<string>();

            if (artists == null)
            {
                return;
            }
            else
            {
                foreach (XmlNode artist in artists)
                {
                    artistSortedSet.Add(artist.InnerText);
                }

                foreach (var sortedArtist in artistSortedSet)
                {
                    Console.WriteLine(sortedArtist);
                }
            }
        }
    }
}
