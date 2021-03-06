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
    public partial class XmlStorage : IXmlStorage
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
            Xdoc = XDocument.Load(source);
            Root = xdoc.Descendants().Where(node => node.Name == Str(NodeName.Storage)).FirstOrDefault();
        }


        private enum NodeName
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

        private enum StorageItemAttr
        {
            ChangingDate,
        }

        private enum LoginAttr
        {
            LoginByPhone,
            LoginByMail,
        }

        private enum PasswordAttr
        {
            IsHide,
        }

        /* рутовая нода для всего хранилища
         * устанавливается в методе SetXDocSource
         */
        private XElement root;
        public XElement Root
        {
            get { return root; }
            private set { root = value; }
        }

        /* текущий тег StorageItem
         * устанавливается через SetCurrentRecord
         */
        private XElement record;
        public XElement Record
        {
            get { return record; }
            private set { record = value; }
        }


        public XElement GetRecordBySiteAndLogin(string siteName, string login)
        {
            return Xdoc.Descendants()
                .Where(tag => tag.Name == Str(NodeName.StorageItem)
                && tag.Element(Str(NodeName.Site)).Value == siteName
                && tag.Element(Str(NodeName.Login)).Value == login)
                .ToArray().First();
        }

        public void SetCurrentRecord(string siteName, string login)
        {
            if (SiteRecordExist(siteName, login))
            {
                Record = GetRecordBySiteAndLogin(siteName, login);
                return;
            }
            Record = null;
        }

        public bool SiteRecordExist(string siteName, string login)
        {
            var siteRecord = Xdoc.Descendants().Where(tag =>
                tag.Name == Str(NodeName.StorageItem) &&
                tag.Element(Str(NodeName.Site)).Value == siteName &&
                tag.Element(Str(NodeName.Login)).Value == login);

            //int count = siteRecord.Count();

            if (siteRecord.Count() > 0) return true;
            return false;
        }


        public string[] GetSiteLogins(string siteName)
        {
            return Xdoc.Descendants().Where(tag => tag.Name == Str(NodeName.Site) && tag.Value == siteName).Select(tag => { return tag.Value; }).ToArray();
        }

        string[] GetSites()
        {
            string[] sites = new string[] { };

            var siteXelements = Xdoc.Descendants().
                    Where(tag => tag.Name == Str(NodeName.StorageItem));

            if (siteXelements.Count() > 0)
            {
                sites = siteXelements.Select(tag => SelectSite(tag)).ToArray();
            }

            return sites;
        }

        /* вспомогательный метод, используется в GetSites()
         */
        private string SelectSite(XElement tag)
        {
            try
            {
                return tag.Element(Str(NodeName.Site)).Value;
            }
            catch
            {
                return null;
            }
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



        private string Str<T>(T name) where T : Enum
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
