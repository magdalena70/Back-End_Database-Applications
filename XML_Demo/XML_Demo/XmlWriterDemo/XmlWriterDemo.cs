using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlWriterDemo
{
    class XmlWriterDemo
    {
        static void Main()
        {
            string xmlFileName = "../../../books.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(xmlFileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("library");
                writer.WriteAttributeString("name", "My Library");
                WriteXmlBook(writer, "My first book",
                "Some Author", "123-123-234-4");
                WriteXmlBook(writer, "Interesting book",
                "Another Author", "123-446-756-3");
                writer.WriteEndElement();
            }
            Console.WriteLine("Document {0} created.", xmlFileName);
        }

        private static void WriteXmlBook(
        XmlWriter writer, string title, string author, string isbn)
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("title", title);
            writer.WriteElementString("author", author);
            writer.WriteElementString("isbn", isbn);
            writer.WriteEndElement();
        }
    }
}
