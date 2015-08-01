using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreatingXMLwithLINQ
{
    class CreatingXMLwithLINQ
    {
        static void Main()
        {
            /*var booksXml = new XElement("books",
            new XElement("book",
                new XAttribute("lang", "BG"),
                new XElement("author", "Don Box"),
                new XElement("title", "ASP.NET"),
                new XElement("price", 50.00) //double
            ),
            new XElement("book",
                new XAttribute("lang", "EN"),
                new XElement("author", "Svetlin Nakov and team"),
                new XElement("title", "Introduction to Programming with C#"),
                new XElement("price", 100.00)
            )
        );

            System.Console.WriteLine(booksXml);

            //booksXml.Save("../../../booksLinq.xml");*/ 


            XNamespace ns = "http://linqinaction.net";
            XNamespace anotherNs = "http://publishers.org";

            var booksNs = new XElement(XName.Get("books", "http://bookstore.org"));
            var bookLinq = new XElement(ns + "book",
                new XElement(ns + "title", "LINQ in Action"),
                new XElement(ns + "authors",
                    new XElement(ns + "author", "Manning"),
                    new XElement(ns + "author", "Steve Eichert"),
                    new XElement(ns + "author", "Jim Wooley")
                ),
                new XElement(anotherNs + "publisher", "Manning")
            );
            booksNs.Add(bookLinq);

            var bookXml = new XElement(ns + "book",
                new XElement(ns + "title", "Beginning XML, 5th Edition"),
                new XElement(ns + "authors",
                    new XElement(ns + "author", "Joe Fawcett, Danny Ayers, Liam R. E. Quin")
                    ),
                new XElement(anotherNs + "publisher", "Wrox")
            );
            booksNs.Add(bookXml);

            Console.WriteLine(booksNs);

            //booksNs.Save("../../../booksNs.xml");
        }
    }
}
