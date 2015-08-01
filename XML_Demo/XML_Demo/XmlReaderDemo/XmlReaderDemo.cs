using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlReaderDemo
{
    class XmlReaderDemo
    {
        static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../../Catalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "name"))
                    {
                        Console.WriteLine("{0} {1}", reader.ReadOuterXmlAsync().Result, reader.ReadElementString());
                    }
                }
            }

            Console.WriteLine("\n All element names in the XML file:");
            using (XmlReader reader = XmlReader.Create("../../../Catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        Console.WriteLine(reader.Name);
                    }
                }
            }
        }
    }
}
