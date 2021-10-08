using System;
using System.Xml;

namespace Test_XPath
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"C:\#csprojects\PasswordStorage\SampleFiles\ReadStorage.xml");

            

            byte a = 0x9a; byte b = 66; a += b;

            GetSomeNodes(xmldoc);

            Console.ReadKey();
        }

        static void GetSomeNodes(XmlDocument doc)
        {
            XmlNodeList storageItems = doc.SelectNodes("Storage/StorageItem");
            storageItems = doc.SelectNodes("Storage/StorageItem/Password");
            storageItems = doc.SelectNodes("//Password");
            storageItems = doc.SelectNodes("//Login");
            //storageItems = doc.SelectSingleNode("//Login");
            storageItems = doc.SelectNodes("//Login[ @LoginByMail = 'false']");
            foreach (XmlNode item in storageItems)
            {
                Console.WriteLine(item.OuterXml);
            }
        }

        [FlagsAttribute()]
        public enum some
        {

        }
    }
}
