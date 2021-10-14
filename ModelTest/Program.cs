using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using Password.Model;

namespace ModelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlStorage storage = new XmlStorage();
            storage.XDocSource = @"C:\#CSprojects\PasswordStorage\SampleFiles\ReadStorage.xml";

            storage.SetRootBySiteName(storage.Sites[0], "vagin");

            storage.LoginByPhone = true;
            storage.Save();



            storage.Save();

            Console.ReadKey();
        }
    }
}
