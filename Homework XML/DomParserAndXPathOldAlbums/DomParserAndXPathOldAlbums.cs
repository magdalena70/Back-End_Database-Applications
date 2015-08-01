using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DomParserAndXPathOldAlbums
{
    class DomParserAndXPathOldAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            //Console.WriteLine(doc.OuterXml);
            Problem07(doc);
            
        }

        private static void Problem07(XmlDocument doc)
        {
            string xPathQuerry = "catalog/album";

            XmlNodeList albumsList = doc.SelectNodes(xPathQuerry);

            foreach (XmlNode album in albumsList)
            {
                DateTime albumReleaseDate = new DateTime(int.Parse(album.Attributes["year"].Value), 1, 1);
                DateTime dateToCompare = DateTime.Now;
                int difference = dateToCompare.Year - albumReleaseDate.Year;
                if (difference < 5)
                {
                    Console.WriteLine("Name {0}, price {1}", album.Attributes["title"].Value, album.Attributes["price"].Value);
                }

            }
        }
    }
}
