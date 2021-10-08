using System;
using System.IO;
using System.Xml;

namespace Test_XmlDocument
{
    //view xml with XmlDocument class
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument xmldoc = new XmlDocument();
            //FileInfo xmlFile = new FileInfo(@"C:\#csprojects\PasswordStorage\SampleFiles\ReadStorage.xml");
            //FileStream stream = xmlFile.OpenRead();
            //xmldoc.Load(stream);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"C:\#csprojects\PasswordStorage\SampleFiles\ReadStorage.xml");
            XmlNode root = xmldoc.DocumentElement;
            ShowXmlDoc(root, 0, "StorageItem");
            Console.ReadKey();
        }

        public static void ShowXmlDoc(XmlNode root, int depth, string nodeItem)
        {
            if (root.Name == nodeItem) Console.WriteLine();

            string offset = new string(' ', depth);
            Console.Write($"{offset}<{root.Name}");
            if(root.Attributes.Count > 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                foreach(XmlAttribute attribute in root.Attributes)
                {
                    Console.WriteLine($"{offset}    {attribute.Name}={attribute.Value}");
                }
                Console.ResetColor();
                Console.WriteLine($"{offset}    >");
            }
            else
            {
                Console.WriteLine($">");
            }

            foreach(XmlNode node in root.ChildNodes)
            {
                if(node.NodeType == XmlNodeType.Text)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{offset}    {node.Value.Trim()}");
                    Console.ResetColor();
                }
                if(node.NodeType == XmlNodeType.Element)
                ShowXmlDoc(node, depth + 4, "StorageItem");
            }
            Console.WriteLine($"{offset}</{root.Name}>");
            if (root.Name == nodeItem) Console.WriteLine();
        }
    }
}
