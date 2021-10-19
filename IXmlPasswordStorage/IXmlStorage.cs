using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace SeemObject
{
    // как получить интерфейс из класса
    // https://docs.microsoft.com/ru-ru/visualstudio/ide/reference/extract-interface?view=vs-2019
    public interface IXmlStorage
    {
        XDocument Xdoc { get; }
        XElement Record { get; }
        XElement Root { get; }

        bool SiteRecordExist(string siteName, string login);
        void SetCurrentRecord(string siteName, string login);

        string SettingDate { get; }
        string Site { get; set; }
        string Login { get; set; }
        string Mail { get; set; }
        string Phone { get; set; }
        bool LoginByMail { get; set; }
        bool LoginByPhone { get; set; }
        string Password { get; set; }
        bool PasswordIsHide { get; set; }
        string ChangeDate { get; }

        void SetNewSite(string newSite);
        void SetNewLogin(string newLogin);
        void SetNewMailBox(string mailbox);
        void SetNewPhoneNumber(string phone);
        void SetNewLoginByMail(bool loginByMail);
        void SetNewLoginByPhone(bool loginByPhone);
        void SetNewPassword(string password);
        void SetNewIsPasswordHide(bool isHide);
        

        string[] Sites { get; }
        string[] GetSiteLogins(string siteName);

        string XDocSource { get; set; }
        object GetXDoc();
        
        int AddNewRecord();
        void RemoveRecord();
        void RemoveRecord(string site, string login);
        void Save();

        
    }
}
