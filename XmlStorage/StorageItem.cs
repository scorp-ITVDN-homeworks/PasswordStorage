using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Password.Model
{
    public class StorageItem
    {
        private string site;
        [XmlStorage(XmlStorageAttribute.Element.Node, nameof(StorageItem), nameof(Site))]
        public  string Site
        {
            get { return site; }
            set { site = value; }
        }

        private string loginText;
        [XmlStorage(XmlStorageAttribute.Element.Node, nameof(StorageItem), "Login")]
        public string LoginText
        {
            get { return loginText; }
            set { loginText = value; }
        }

        private bool loginByPhone;
        [XmlStorage(XmlStorageAttribute.Element.Attribute, nameof(StorageItem), "Login")]
        public bool LoginByPhone
        {
            get { return loginByPhone; }
            set { loginByPhone = value; }
        }

        private bool loginByMail;
        [XmlStorage(XmlStorageAttribute.Element.Attribute, nameof(StorageItem), "Login")]
        public bool LoginByMail
        {
            get { return loginByMail; }
            set { loginByMail = value; }
        }

        private string phoneNumber;
        [XmlStorage(XmlStorageAttribute.Element.Node, nameof(StorageItem), nameof(PhoneNumber))]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private string password;
        [XmlStorage(XmlStorageAttribute.Element.Node, nameof(StorageItem), nameof(Password))]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private bool isPasswordHide;
        [XmlStorage(XmlStorageAttribute.Element.Attribute, nameof(StorageItem), nameof(Password))]
        public bool IsPasswordHide
        {
            get { return isPasswordHide; }
            set { isPasswordHide = value; }
        }

        private DateTime settingDate;
        [XmlStorage(XmlStorageAttribute.Element.Attribute, nameof(Password), nameof(SettingDate))]
        public DateTime SettingDate
        {
            get { return settingDate; }
            set { settingDate = value; }
        }        
    }    
}
