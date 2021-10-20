using System;
using System.Collections.ObjectModel;
using SeemObject;

namespace PasswordStorage.ViewModel
{
    public partial class StorageVM 
    {
        private IXmlStorage storageModel;
        public IXmlStorage StorageModel
        {
            get { return storageModel; }
            set { storageModel = value; }
        }

        public StorageVM(IXmlStorage storageModel)
        {
            StorageModel = storageModel;
        }

        private ObservableCollection<Record> loginRecords;
        public ObservableCollection<Record> LoginRecords
        {
            get { return loginRecords; }
            set { loginRecords = value; }
        }

        private void SetRecordsList()
        {
            
        }

        public class Record
        {
            public string Site { get; set; }
            public string Login { get; set; }
            public string Mail { get; set; }
            public string Phone { get; set; }
            public bool IsLoginByPhone { get; set; } 
            public bool IsLoginByMail { get; set; }
            public string Password { get; set; }
            public bool HidePassword { get; set; }
            public DateTime ChangingDate { get; }
            public DateTime SettingDate { get; }
        }
    }
}
