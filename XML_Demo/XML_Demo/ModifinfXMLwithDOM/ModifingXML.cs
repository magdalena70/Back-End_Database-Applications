using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;

namespace ModifinfXMLwithDOM
{
    class ModifingXML
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            //Console.WriteLine(doc.OuterXml);
            //Console.WriteLine(doc.InnerText);

            string culture = doc.DocumentElement.Attributes["culture"].Value;
            CultureInfo numberFormat = new CultureInfo(culture);

            foreach (XmlNode node in doc.DocumentElement)
            {
                if (node.Attributes.Count == 0)
                {
                    Console.WriteLine("no attribute");
                }
                else
                {
                    foreach (XmlAttribute atr in node.Attributes)
                    {
                        Console.WriteLine("Attribute: {0} = {1}", atr.Name, atr.Value);
                        if (atr.Name == "rating" && atr.Value == "my favorite")
                        {
                            string currentPriceStr = node["price"].InnerText;
                            Console.WriteLine("Current price: {0}", currentPriceStr);
                            decimal currentPrice = Decimal.Parse(currentPriceStr, numberFormat);
                            decimal newPrice = currentPrice * 2;
                            node["price"].InnerText = newPrice.ToString(numberFormat);
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Modified XML document:");
            Console.WriteLine(doc.OuterXml);

            doc.Save("../../../CatalogNew.xml");
        }
    }
}
