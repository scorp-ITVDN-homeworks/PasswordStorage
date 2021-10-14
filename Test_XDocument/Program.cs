using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Test_XDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Load(@"C:\#csprojects\PasswordStorage\SampleFiles\ReadStorage.xml");

            GetSingleValueOfNode(xdoc);
            Console.ReadKey();

        }

        static void ShowSome(XDocument xdoc)
        {
            IEnumerable<XElement> logins = xdoc.Descendants().Where(x => x.Name == "Login");

            foreach(XElement login in logins)
            {
                Console.WriteLine(login.Value);
            }
        }

        static void GetSingleValueOfNode(XDocument xdoc)
        {
            IEnumerable<XElement> elements = xdoc.Descendants()
                .Where(node => node.Name == "StorageItem");
            foreach(XElement elem in elements)
            {
                foreach(XElement item in elem.Descendants())
                {
                    if (item.HasElements && ComplexElementHasValue(item))
                    {
                        Console.WriteLine($"{item.Name} = {GetComplexElementValue(item)}");
                        continue;
                    }
                    if (!item.HasElements) 
                    {
                        Console.WriteLine($"{item.Name} = {item.Value}");
                    }
                }
                Console.WriteLine(new string('-', 50));
            }
            
        }

        static string GetComplexElementValue(XElement xmlTag)
        {
            if (xmlTag.FirstNode.NodeType == XmlNodeType.Text)
            {
                return xmlTag.FirstNode.ToString().Trim();
            }
            if(xmlTag.LastNode.NodeType == XmlNodeType.Text)
            {
                return xmlTag.LastNode.ToString().Trim();
            }
            return null;
        }

        static bool ComplexElementHasValue(XElement xmlTag)
        {
            if (xmlTag.FirstNode.NodeType == XmlNodeType.Text || xmlTag.LastNode.NodeType == XmlNodeType.Text) return true;
            return false;
        }
    }
}
