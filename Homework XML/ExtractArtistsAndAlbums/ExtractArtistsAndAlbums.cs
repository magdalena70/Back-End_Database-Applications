using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtractArtistsAndAlbums
{
    class ExtractArtistsAndAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            //Console.WriteLine(doc.OuterXml);
            var artists = doc.SelectNodes("//album/artist");

            var artistAndAlbums = new Dictionary<string, int>();

            foreach (XmlNode artist in artists)
            {
                if (!artistAndAlbums.ContainsKey(artist.InnerText))
                {
                    artistAndAlbums.Add(artist.InnerText, 0);
                }
                artistAndAlbums[artist.InnerText]++;
            }

            foreach (var artist in artistAndAlbums)
            {
                Console.WriteLine("Artist: {0} -> albums: {1}", artist.Key, artist.Value);
            }
        }
    }
}
