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

            storage.SetCurrentRecord(storage.Sites[0], "vagin");

            storage.LoginByPhone = false;
            storage.Save();

            //storage.SetNewSite("https://geekboards.ru/");
            //storage.SetNewLogin("Mechanic");
            //storage.SetNewMailBox("nebegika@yandex.ru");
            //storage.SetNewPhoneNumber("+79516575648");
            //storage.SetNewLoginByMail(false);
            //storage.SetNewLoginByPhone(false);
            //storage.SetNewPassword("==kuberneT!S==");
            //storage.SetNewIsPasswordHide(false);

            //storage.AddNewRecord();


            storage.RemoveRecord("https://geekboards.ru/", "Mechanic");
            storage.Save();

            Console.ReadKey();
        }
    }
}
