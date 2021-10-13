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

        public void SetXDocSource(string source)
        {
            Xdoc = new XDocument();
            Xdoc = XDocument.Load(source);
        }

        public List<string[]> ViewStorageItems()
        {
            List<string[]> itemsList = new List<string[]>();

            IEnumerable<XElement> records = Xdoc.Descendants().Where(record => record.NodeType == XmlNodeType.Element && record.Name == Str(NodeName.StorageItem));

            foreach(XElement record in records)
            {
                itemsList.Add(StorageItemInfo(record));
            }

            return itemsList;
        }

        public string[] StorageItemInfo(XElement storageItem)
        {
            if (storageItem.Name != Str(NodeName.StorageItem)) return null;

            string[] values = new string[] { };

            foreach(XElement record in storageItem.Elements())
            {
                Array.Resize(ref values, values.Length + 1);
                values[values.Length - 1] = $"{record.Name} = {record.Value}";
            }

            return values;
        }

        public static string Str<T>(T name) where T: Enum
        {
            return name.ToString();
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

        public enum AttributeName
        {
            LoginByPhone,
            LoginByMail,
            IsHide,
            Value,
        }
    }
}
