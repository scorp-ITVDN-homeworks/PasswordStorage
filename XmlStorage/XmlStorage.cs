using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SeemObject;

namespace Password.Model
{
    public partial class XmlStorage
    {
        public XmlStorage()
        {

        }

        public object GetXDoc()
        {
            return Xdoc;
        }

        private void SetXDocSource(string source)
        {
            Xdoc = new XDocument();
            Xdoc = XDocument.Load(source);
        }        

        public enum NodeName
        {
            Storage,
            StorageItem,
            Site,
            Login,
            Mailbox,
            PhoneNumber,
            Password,
            SettingDate,
        }

        public enum StorageItemAttr
        {
            ChangingDate,
        }

        public enum LoginAttr
        {
            LoginByPhone,
            LoginByMail,            
        }

        public enum PasswordAttr
        {
            IsHide,            
        }


        private XElement record;
        public XElement Record
        {
            get { return record; }
            private set { record = value; }
        }


        private string[] GetSites()
        {
            string[] sites = (Xdoc.Descendants().
                Where(tag => tag.Name == Str(NodeName.StorageItem))
                .Select(tag => { return tag.Element(Str(NodeName.Site)).Value; })).ToArray();
            return sites;
        }

        public void SetRootBySiteName(string siteName, string login)
        {
            if (SiteRecordExist(siteName, login))
            {
                Record = GetRootBySiteName(siteName, login);
                return;
            }
            Record = null;
        }

        public bool SiteRecordExist(string siteName, string login)
        {
            return Array.Exists(Sites, siteRecord => siteRecord == siteName);
        }

        public string[] GetSiteLogins(string siteName)
        {
            return Xdoc.Descendants().Where(tag => tag.Name == Str(NodeName.Site) && tag.Value == siteName).Select(tag => { return tag.Value; }).ToArray();
        }

        private string GetSite()
        {
            return Record.Element(Str(NodeName.Site)).Value;
        }

        private string GetLogin()
        {
            return Record.Element(Str(NodeName.Login)).Value;
        }

        private string GetMail()
        {
            return Record
                .Element(Str(NodeName.Mailbox)).Value;
        }

        private string GetPhone()
        {
            return Record
                .Element(Str(NodeName.PhoneNumber)).Value;
        }

        private string GetPassword()
        {
            XElement password = Record
                .Element(Str(NodeName.Password));
            return GetComplexElementValue(password);
        }

        private string GetSettingDate()
        {
            return Record
                .Element(Str(NodeName.SettingDate)).Value;
        }

        private string GetChangingDate()
        {
            return Record
                .Attribute(Str(StorageItemAttr.ChangingDate)).Value;
        }

        private bool IsLoginByPhone()
        {
            return bool.Parse(Record
                .Element(Str(NodeName.Login))
                .Attribute(Str(LoginAttr.LoginByPhone)).Value);
        }

        private bool IsLoginByMail()
        {
            return bool.Parse(Record
                .Element(Str(NodeName.Login))
                .Attribute(Str(LoginAttr.LoginByMail)).Value);
        }

        private bool IsPasswordHide()
        {
            return bool.Parse(
                Record
                .Element(Str(NodeName.Password))
                .Attribute(Str(PasswordAttr.IsHide)).Value
                );
        }

        private void SetSite(string newSiteName)
        {
            Record.Element(Str(NodeName.Site)).Value = newSiteName;
            Save();
            Sites = GetSites();
        }

        private void SetLogin(string newlogin)
        {
            Record.Element(Str(NodeName.Login)).Value = newlogin;
        }

        private void SetMail(string newMail)
        {
            Record.Element(Str(NodeName.Mailbox)).Value = newMail;
        }

        private void SetPhone(string newPhone)
        {
            Record.Element(Str(NodeName.PhoneNumber)).Value = newPhone;
        }

        private void SetPassword(string newPassword)
        {
            Record.Element(Str(NodeName.Password)).FirstNode.ReplaceWith(newPassword);
            //Record.Element(Str(NodeName.Password)).FirstNode.Remove();
            //Record.Element(Str(NodeName.Password)).AddFirst(newPassword);
        }

        private void SetCreationDate()
        {
            Record.Element(Str(NodeName.SettingDate)).Value = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void SetChangingDate()
        {
            Record.Attribute(Str(StorageItemAttr.ChangingDate)).Value = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void SetLoginAsPhone(bool set)
        {
            Record.Element(Str(NodeName.Login)).Attribute(Str(LoginAttr.LoginByPhone)).Value = set.ToString().ToLower();
        }

        private void SetLoginAsMail(bool set)
        {
            Record.Element(Str(NodeName.Login)).Attribute(Str(LoginAttr.LoginByMail)).Value = set.ToString().ToLower();
        }

        private void SetPasswordHide(bool set)
        {
            Record.Element(Str(NodeName.Password)).Attribute(Str(PasswordAttr.IsHide)).Value = set.ToString().ToLower();
        }


        public void Save()
        {
            Xdoc.Save(XDocSource);
        }


        private XElement GetRootBySiteName(string siteName, string login)
        {
            return Xdoc.Descendants()
                .Where(tag => tag.Name == Str(NodeName.StorageItem)
                && tag.Element(Str(NodeName.Site)).Value == siteName 
                && tag.Element(Str(NodeName.Login)).Value == login)
                .ToArray().First();
        }

        private XElement ReturtnSelection(XElement tag, string siteName)
        {
            XElement some = (tag.Element("Site").Value == siteName) ? tag : null;
            return some;
        }

        private string Str<T>(T name) where T: Enum
        {
            return name.ToString();
        }

        private string GetComplexElementValue(XElement xmlTag)
        {
            if (xmlTag.FirstNode.NodeType == XmlNodeType.Text)
            {
                return xmlTag.FirstNode.ToString().Trim();
            }
            if (xmlTag.LastNode.NodeType == XmlNodeType.Text)
            {
                return xmlTag.LastNode.ToString().Trim();
            }
            return null;
        }
    }
}
