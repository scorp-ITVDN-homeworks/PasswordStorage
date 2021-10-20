using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using Password.Model;

using System.IO;

namespace ModelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo(@"./");
            string path = @$"{GetProjectDir(info, ".csproj")}\TestXml\TestStorage.xml";
            string site = "http://somesite.com";
            string login = "loginBegin";

            XmlStorage storage = new XmlStorage();
            storage.XDocSource = path;

            storage.AddNewRecord(site, login);
            storage.Save();
            //Console.ReadKey();
            //storage.SetCurrentRecord(site, login);
            //storage.RemoveRecord();
            //storage.RemoveRecord(site, login);
            storage.Save();

            Console.WriteLine("done!");
            Console.ReadKey();
        }

        static string GetProjectDir(DirectoryInfo currentDir, string extension)
        {           
            var filesExtensions = currentDir.GetFiles().Where(file => file.Extension == extension);
            if (filesExtensions.Any())
            {
                return currentDir.FullName;
            }
            else
            {
                currentDir = Directory.GetParent(currentDir.FullName);
                return GetProjectDir(currentDir, extension);
            }
        }

        static void CreateXmlInAssemblyFolder()
        {
            XDocument newXdoc = new XDocument();

            XElement storageItem = new XElement("Storage");

            newXdoc.Add(storageItem);

            newXdoc.Save("NewStorage.xml");
        }

        static void StorageExists(string xmlFileName)
        {
            FileInfo newStorage = new FileInfo(xmlFileName);
            Console.WriteLine(newStorage.Exists);
        }

        static void CreateNewRecord(XmlStorage xmlStorage)
        {
            Console.Write("Input new site: ");
            string site = Console.ReadLine();

            Console.Write("Input new login: ");
            string login = Console.ReadLine();

            Console.Write("Input new mailbox: ");
            string mail = Console.ReadLine();

            Console.Write("Input new phone: ");
            string phone = Console.ReadLine();

            Console.WriteLine("Login by mail? (y/n): ");
            bool loginByMail = Console.ReadLine() == "y" ? true : false;

            Console.WriteLine("Login by phone? (y/n): ");
            bool loginByPhone = Console.ReadLine() == "y" ? true : false;

            Console.WriteLine("Input password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Hide login in viewer? (y/n): ");
            bool hideLogin = Console.ReadLine() == "y" ? true : false;

            


            //storage.RemoveRecord("https://geekboards.ru/", "Mechanic");
            xmlStorage.Save();
        }

        static void CreateWrap(XmlStorage xmlStorage)
        {
            while (true)
            {
                CreateNewRecord(xmlStorage);

                Console.Clear();
                Console.Write("Add another record? (y/n): ");
                if (Console.ReadLine() == "y") continue;
                else break;
            }
        }

        static void RemoveRecord(XmlStorage xmlStorage, string site, string login)
        {
            xmlStorage.RemoveRecord(site, login);
        }

        static void CreateBlankRecord(XmlStorage xmlStorage)
        {
            xmlStorage.CreateBlankRecord();

            xmlStorage.Login = "SomeNewLogin";
            xmlStorage.Site = "https://somenewsite.com";

        }

    }
}
