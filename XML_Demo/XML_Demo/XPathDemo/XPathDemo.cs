using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XPathDemo
{
    class XPathDemo
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            string xPathAlbum = "//album[@rating='my favorite']";

            XmlNodeList albumsList = doc.SelectNodes(xPathAlbum);
            foreach (XmlNode album in albumsList)
            {
                //string albumName = album.SelectSingleNode("name").InnerText;
                if (album.ChildNodes.Count != 0)
                {
                    Console.WriteLine("{0} ->", album.Name);
                    foreach (XmlNode child in album.ChildNodes)
                    {
                        if(child.ChildNodes.Count == 1 ){
                            Console.WriteLine(child.Name + ": " + child.InnerText);
                        }

                        if (child.ChildNodes.Count > 1)
                        {
                            string xPathAlbumSong = "//album[@rating='my favorite']/songs/song";
                            Console.WriteLine("{0} ->", child.Name);
                            XmlNodeList songsList = doc.SelectNodes(xPathAlbumSong);
                            foreach (XmlNode song in songsList)
                            {
                                if(song.ChildNodes.Count > 0){
                                    Console.WriteLine("  {0}:", song.Name);
                                    foreach (XmlNode s in song.ChildNodes)
                                    {
                                        Console.WriteLine("\t{0} {1}", s.Name, s.InnerText);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
