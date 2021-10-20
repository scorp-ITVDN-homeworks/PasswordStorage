using System;
using System.Collections.ObjectModel;
using SeemObject;
using MVVMadds;

using System.Windows.Input;

namespace PasswordStorage.ViewModel
{
    public partial class StorageVM : ObservableObject
    {

        private string siteSet;
        public string SiteSet
        {
            get { return siteSet; }
            set 
            {
                siteSet = value;
                OnPropertyChanged(nameof(SiteSet));
            }
        }

        private string loginSet;
        public string LoginSet
        {
            get { return loginSet; }
            set
            {
                loginSet = value;
                OnPropertyChanged(nameof(LoginSet));
            }
        }

        private string mailSet;
        public string MailSet
        {
            get { return mailSet; }
            set
            {
                mailSet = value;
                OnPropertyChanged(nameof(MailSet));
            }
        }

        private string phoneSet;
        public string PhoneSet
        {
            get { return phoneSet; }
            set
            {
                phoneSet = value;
                OnPropertyChanged(nameof(PhoneSet));
            }
        }

        private bool loginByMailSet;
        public bool LoginByMailSet
        {
            get { return loginByMailSet; }
            set
            {
                loginByMailSet = value;
                OnPropertyChanged(nameof(LoginByMailSet));
            }
        }

        private bool loginByPhoneSet;
        public bool LoginByPhoneSet
        {
            get { return loginByPhoneSet; }
            set
            {
                loginByPhoneSet = value;
                OnPropertyChanged(nameof(LoginByPhoneSet));
            }
        }

        private string passwordSet;
        public string PasswordSet
        {
            get { return passwordSet; }
            set
            {
                passwordSet = value;
                OnPropertyChanged(nameof(PasswordSet));
            }
        }

        private bool isPasswordHide;
        public bool IsPasswordHideSet
        {
            get { return isPasswordHide; }
            set
            {
                isPasswordHide = value;
                OnPropertyChanged(nameof(IsPasswordHideSet));
            }
        }

        RelayCommand cmdSetNewRecord;

        ICommand CmdSetNewRecord
        {
            get
            {
                if (cmdSetNewRecord == null) 
                {
                    cmdSetNewRecord = new RelayCommand(SetNewRecordExec, SetNewRecordCanExec);                    
                }
                return cmdSetNewRecord;
            }
        }

        private void SetNewRecordExec(object obj)
        {
            storageModel.AddNewRecord(SiteSet, LoginSet);
            storageModel.Mail = MailSet;
            storageModel.Phone = PhoneSet;
            storageModel.Password = PasswordSet;
            storageModel.LoginByMail = LoginByMailSet;
            storageModel.LoginByPhone = LoginByPhoneSet;
            storageModel.PasswordIsHide = IsPasswordHideSet;
        }

        private bool SetNewRecordCanExec(object obj)
        {
            return true;
        }

    }
}
