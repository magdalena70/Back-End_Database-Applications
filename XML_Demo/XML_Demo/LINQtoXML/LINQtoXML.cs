using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQtoXML
{
    class LINQtoXML
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("../../../booksNew.xml");

                var books =
                    from book in doc.Descendants("book")
                    where book.Element("price").Value.Contains("0")
                    select new
                    {
                        Title = book.Element("title").Value,
                        Author = book.Element("author").Value
                    };
                Console.WriteLine("Found {0} books:", books.Count());
                foreach (var book in books)
                {
                    Console.WriteLine(" - {0} (by {1})", book.Title, book.Author);
                }
        }
    }
}
