using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace XPathNavigatorDemo
{
    class XPathNavigatorDemo
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../books.xml");

            XPathNavigator nav = doc.CreateNavigator();
            string xPathBook = "/library/book";
            XPathNodeIterator iter = nav.Select(xPathBook);

            while (iter.MoveNext())
            {
                Console.WriteLine("{0}", iter.Current.InnerXml);
                iter.Current.AppendChildElement("", "price", "", "0"); //string
            }

            //doc.Save("../../../booksNew.xml");
        }
    }
}
