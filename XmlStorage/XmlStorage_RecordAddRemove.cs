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
    public partial class XmlStorage
    {
        private HybridDictionary NewRecordInfo = new HybridDictionary();

        public void SetNewSite(string newSite)              { NewRecordInfo.Add(NodeName.Site,newSite); }
        public void SetNewLogin(string newLogin)            { NewRecordInfo.Add(NodeName.Login, newLogin); }
        public void SetNewLoginByMail(bool loginByMail)     { NewRecordInfo.Add(LoginAttr.LoginByMail, loginByMail.ToString().ToLower()); }
        public void SetNewLoginByPhone(bool loginByPhone)   { NewRecordInfo.Add(LoginAttr.LoginByPhone, loginByPhone.ToString().ToLower()); }
        public void SetNewMailBox(string mailbox)           { NewRecordInfo.Add(NodeName.Mailbox, mailbox); }
        public void SetNewPhoneNumber(string phone)         { NewRecordInfo.Add(NodeName.PhoneNumber, phone); }
        public void SetNewPassword(string password)         { NewRecordInfo.Add(NodeName.Password, password); }
        public void SetNewIsPasswordHide(bool isHide)       { NewRecordInfo.Add(PasswordAttr.IsHide, isHide.ToString().ToLower()); }

        public int AddNewRecord()
        {
            if (NewRecordInfo.Count < 0) return -1;

            XElement storageItem = new XElement(Str(NodeName.StorageItem));
            XAttribute changingDate = new XAttribute(Str(StorageItemAttr.ChangingDate), DateTime.Now.ToString("dd.MM.yyyy"));
            storageItem.Add(changingDate);

            XElement site = new XElement(Str(NodeName.Site), NewRecordInfo[NodeName.Site]);

            XElement login = new XElement(Str(NodeName.Login), NewRecordInfo[NodeName.Login]);
            XAttribute loginByMail = new XAttribute(Str(LoginAttr.LoginByMail), NewRecordInfo[LoginAttr.LoginByMail].ToString().ToLower());
            XAttribute loginByPhone = new XAttribute(Str(LoginAttr.LoginByPhone), NewRecordInfo[LoginAttr.LoginByPhone].ToString().ToLower());
            login.Add(loginByMail);
            login.Add(loginByPhone);

            XElement mailbox = new XElement(Str(NodeName.Mailbox), NewRecordInfo[NodeName.Mailbox]);
            XElement phoneNumber = new XElement(Str(NodeName.PhoneNumber), NewRecordInfo[NodeName.PhoneNumber]);

            XElement password = new XElement(Str(NodeName.Password), NewRecordInfo[NodeName.Password]);
            XAttribute isHide = new XAttribute(Str(PasswordAttr.IsHide), NewRecordInfo[PasswordAttr.IsHide]);
            XElement settingDate = new XElement(Str(NodeName.SettingDate), DateTime.Now.ToString("dd.MM.yyyy"));
            password.Add(isHide);
            password.Add(settingDate);

            storageItem.Add(site, login, mailbox, phoneNumber, password);
            Root.Add(storageItem);

            NewRecordInfo.Clear();

            return 1;
        }

        public void RemoveRecord(string site, string login)
        {
            XElement recordToRemove = Xdoc.Descendants()
                .Where( 
                node => node.Name == "StorageItem" 
                && node.Element(Str(NodeName.Site)).Value == site 
                && node.Element(Str(NodeName.Login)).Value == login)
                .First();

            recordToRemove.Remove();
        }

        public void RemoveRecord()
        {

        }
    }
}
