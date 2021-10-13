using System;
using Password.Model;

namespace ModelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlStorage storage = new XmlStorage();
            storage.SetXDocSource(@"C:\#CSprojects\PasswordStorage\SampleFiles\ReadStorage.xml");

            foreach(string[] str in storage.ViewStorageItems())
            {
                foreach(string s in str)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine(new string('-', 50));
            }

            Console.ReadKey();
        }
    }
}
