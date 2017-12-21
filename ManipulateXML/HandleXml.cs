using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace Amphenol.ManipulateXML
{
    class HandleXml
    {
        public void InsertXmlNode()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("bookstore.xml");

            XmlNode bookstoreNode = doc.SelectSingleNode("bookstore");      /* Find the <bookstore> node */

            XmlElement newBookNode = doc.CreateElement("book");     /* Create a new <book> node */
            newBookNode.SetAttribute("genre", "Programming");     /* Set the attribute for "genre" of <book> node */
            newBookNode.SetAttribute("ISBN", "2-4587-1");

            XmlElement titleElement = doc.CreateElement("title");   /* Create a new node <title> */
            titleElement.InnerText = "C#从入门到精通";        /* Set the text for <title> node */

            XmlElement authorElement = doc.CreateElement("author");
            authorElement.InnerText = "Frederick Hsu";

            XmlElement priceElement = doc.CreateElement("price");
            priceElement.InnerText = "58.34";

            /* Append the <title>, <author> and <price> nodes into the <book> as child nodes. */
            newBookNode.AppendChild(titleElement);
            newBookNode.AppendChild(authorElement);
            newBookNode.AppendChild(priceElement);

            /* Append <book> node under <bookstore> node */
            bookstoreNode.AppendChild(newBookNode);

            /* Save the entire .xml document */
            doc.Save("bookstore.xml");
        }

        public void ModifyXmlNode()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("bookstore.xml");

            XmlNodeList bookNodeList = doc.SelectSingleNode("bookstore").ChildNodes;
            foreach (XmlNode node in bookNodeList)      /* Transverse all <book> nodes under the <bookstore> node list. */
            {
                XmlElement elem = (XmlElement)node;     /* Convert the XmlNode to XmlElement */
                if (elem.GetAttribute("genre") == "Programming")
                {
                    elem.SetAttribute("genre", "C#");


                    XmlNodeList nodes = elem.ChildNodes;    /* Get all child nodes under <book> node */
                    foreach (XmlNode xn in nodes)
                    {
                        XmlElement nodeElement = (XmlElement)xn;
                        if (nodeElement.Name == "author")
                        {
                            nodeElement.InnerText = "Bjorn Cederberg";      /* Change the <author> node's content */
                            break;
                        }
                    }
                    break;
                }
            }
            doc.Save("bookstore.xml");
        }

        public void RemoveXmlNode()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("bookstore.xml");

            XmlNodeList nodes = doc.SelectSingleNode("bookstore").ChildNodes;
            foreach (XmlNode node in nodes)
            {
                XmlElement elem = (XmlElement)node;
                if (elem.GetAttribute("genre") == "fantasy")
                {
                    elem.RemoveAttribute("genre");
                }
                else if (elem.GetAttribute("genre") == "C#")
                {
                    elem.RemoveAll();
                }
            }
            doc.Save("bookstore.xml");
        }

        public void DisplayAllData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("bookstore.xml");

            XmlNode bookstoreNode = doc.SelectSingleNode("bookstore");
            XmlNodeList nodes = bookstoreNode.ChildNodes;

            foreach (XmlNode node in nodes)
            {
                XmlElement elem = (XmlElement)node;
                Console.WriteLine(elem.GetAttribute("genre"));
                Console.WriteLine(elem.GetAttribute("ISBN"));

                XmlNodeList childNodes = elem.ChildNodes;
                foreach (XmlNode xn in childNodes)
                {
                    Console.WriteLine(xn.InnerText);
                }
            }
        }
    }
}
