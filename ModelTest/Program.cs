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
            string xmlFileName = "NewStorage.xml";
            StorageExists(xmlFileName);

            XmlStorage storage = new XmlStorage();
            storage.XDocSource = xmlFileName;

            storage.RemoveRecord("https://gpsm.ru", "bim-leader");
            storage.Save();
                

            Console.ReadKey();
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

            xmlStorage.SetNewSite(site);
            xmlStorage.SetNewLogin(login);
            xmlStorage.SetNewMailBox(mail);
            xmlStorage.SetNewPhoneNumber(phone);
            xmlStorage.SetNewLoginByMail(loginByMail);
            xmlStorage.SetNewLoginByPhone(loginByPhone);
            xmlStorage.SetNewPassword(password);
            xmlStorage.SetNewIsPasswordHide(hideLogin);

            xmlStorage.AddNewRecord();


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

    }
}
