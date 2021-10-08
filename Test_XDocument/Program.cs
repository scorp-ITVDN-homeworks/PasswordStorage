using System;
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

            ShowSome(xdoc);
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
    }
}
