using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Demo
{
    class DomParser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Music.xml");
            //doc.Load("../../../Catalog.xml");
            //Console.WriteLine(doc.OuterXml);
            //Console.WriteLine();

            XmlNode rootNode = doc.DocumentElement;
            Console.WriteLine("Root node: {0}", rootNode.Name);

            foreach (XmlAttribute atr in rootNode.Attributes)
            {
                Console.WriteLine("Attribute: {0} = {1}", atr.Name, atr.Value);
            }
            Console.WriteLine();

            var count = 0;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if(node.ChildNodes.Count != 0){
                    count++;
                    Console.WriteLine("{0} #{1}", node.Name, count);
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        Console.WriteLine("{2} {0} -> {1}",
                        childNode.Name, childNode.InnerText, childNode.ParentNode.Name);   
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
