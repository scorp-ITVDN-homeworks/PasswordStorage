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
        private XDocument xdoc;
        public  XDocument Xdoc
        {
            get { return xdoc; }
            private set 
            { 
                xdoc = value;                
            }
        }

        private string xDocSource;
        public  string XDocSource
        {
            get { return xDocSource; }
            set 
            { 
                xDocSource = value;
                SetXDocSource(value);
                Sites = GetSites();
            }
        }

        public string[] Sites
        {
            get;
            private set;
        }       

        public string Site
        {
            get { return GetSite(); }
            set
            {
                SetChangingDate();
                SetSite(value);
            }
        }

        public string Login
        {
            get { return GetLogin(); }
            set 
            {
                SetChangingDate();
                SetLogin(value);                
            }
        }

        public string Mail
        {
            get { return GetMail(); }
            set 
            {
                SetChangingDate();
                SetMail(value);                
            }
        }

        public string Phone
        {
            get { return GetPhone(); }
            set 
            {
                SetChangingDate();
                SetPhone(value);                
            }
        }

        public string Password
        {
            get { return GetPassword(); }
            set 
            {
                SetChangingDate();
                SetPassword(value);
            }
        }

        public string SettingDate
        {
            get { return GetSettingDate(); }            
        }

        public string ChangeDate
        {
            get { return GetChangingDate(); }
        }

        public bool LoginByPhone
        {
            get { return IsLoginByPhone(); }
            set
            {
                SetChangingDate();
                SetLoginAsPhone(value);
                if(value == true)
                {
                    LoginByMail = false;
                }
            }
        }

        public bool LoginByMail
        {
            get { return IsLoginByMail(); }
            set
            {
                SetChangingDate();
                SetLoginAsMail(value);
                if(value == true)
                {
                    LoginByPhone = false;
                }
            }
        }

        public bool PasswordIsHide
        {
            get { return IsPasswordHide(); }
            set
            {
                SetChangingDate();
                SetPasswordHide(value);
            }
        }
        
    }
}
