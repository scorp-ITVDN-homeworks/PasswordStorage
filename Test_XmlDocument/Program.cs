using System;
using System.IO;
using System.Xml;

namespace Test_XmlDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmldoc = new XmlDocument();
            FileInfo xmlFile = new FileInfo(@"C:\#csprojects\PasswordStorage\SampleFiles\ReadStorage.xml");
            FileStream stream = xmlFile.OpenRead();
            xmldoc.Load(stream);

            XmlNode root = xmldoc.DocumentElement;

            foreach(XmlNode node in root.ChildNodes)
            {
                Console.WriteLine(node.Name);
            }

            Console.ReadKey();
        }

        public void ShowXmlDoc(XmlNode root)
        {
            foreach(XmlNode node in root.ChildNodes)
            {

            }
        }
    }
}
