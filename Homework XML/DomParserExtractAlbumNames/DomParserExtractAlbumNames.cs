using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DomParserExtractAlbumNames
{
    class DomParserExtractAlbumNames
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            //Console.WriteLine(doc.OuterXml);

            var rootNode = doc.DocumentElement;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var xmlElement = node["name"];
                if (xmlElement != null)
                {
                    Console.WriteLine(xmlElement.InnerText);
                }
            }
        }
    }
}
