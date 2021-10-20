using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using SeemObject;
using System.Collections.Specialized;

namespace Password.Model
{
    public partial class XmlStorage : IXmlStorage
    { 
        public void AddNewRecord(string site, string login)
        {
            if (SiteRecordExist(site, login)) return;
            CreateBlankRecord();
            Site = site;
            Login = login;
        }

        public void CreateBlankRecord()
        {
            string blank = "blank";
            XElement storageItem = new XElement(Str(NodeName.StorageItem));
            XAttribute changingDate = new XAttribute(Str(StorageItemAttr.ChangingDate), DateTime.Now.ToString("dd.MM.yyyy"));
            storageItem.Add(changingDate);

            XElement site = new XElement(Str(NodeName.Site), blank);

            XElement login = new XElement(Str(NodeName.Login), blank);
            XAttribute loginByMail = new XAttribute(Str(LoginAttr.LoginByMail), blank);
            XAttribute loginByPhone = new XAttribute(Str(LoginAttr.LoginByPhone), blank);
            login.Add(loginByMail);
            login.Add(loginByPhone);

            XElement mailbox = new XElement(Str(NodeName.Mailbox), blank);
            XElement phoneNumber = new XElement(Str(NodeName.PhoneNumber), blank);

            XElement password = new XElement(Str(NodeName.Password), blank);
            XAttribute isHide = new XAttribute(Str(PasswordAttr.IsHide), blank);
            XElement settingDate = new XElement(Str(NodeName.SettingDate), blank);
            password.Add(isHide);
            password.Add(settingDate);

            storageItem.Add(site, login, mailbox, phoneNumber, password);
            Root.Add(storageItem);

            Record = storageItem;
        }

        public void RemoveBlankRecord()
        {
            var blankRecord = Root.Descendants().Where(node =>
            node.Name == Str(NodeName.StorageItem) &&
            node.Element(Str(NodeName.Site)).Value == "blank"
            && node.Element(Str(NodeName.Login)).Value == "blank").ToArray();

            int steps = blankRecord.Length;
            for(int i = 0; i < steps; i++)
            {
                blankRecord[i].Remove();
            }
        }

        public void RemoveRecord(string site, string login)
        {
            if (SiteRecordExist(site, login))
            {
                XElement recordToRemove = Xdoc.Descendants()
                    .Where( 
                    node => node.Name == "StorageItem" 
                    && node.Element(Str(NodeName.Site)).Value == site 
                    && node.Element(Str(NodeName.Login)).Value == login)
                    .First();

                recordToRemove.Remove();
            }
        }

        public void RemoveRecord()
        {
            Record?.Remove();
        }        
        
    }
}
