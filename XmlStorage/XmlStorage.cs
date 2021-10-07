using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

using SeemObject;

namespace Password.Model
{
    public partial class XmlStorage : IXmlStorage
    {
        public XmlStorage()
        {

        }

        public void SetXmlSource(string source)
        {
           XmlSource = source;
        }

        public void GetFileFromSource()
        {
            //TODO: проверка корректности файла
            XmlSourceFile = new FileInfo(XmlSource);
        }

        public void OpenAsXml()
        {
            Reader = new XmlTextReader(XmlSourceFile.Open(FileMode.Open));
        }

        public void OpenAsFile()
        {
            throw new NotImplementedException();
        }

        public void CloseXml()
        {
            throw new NotImplementedException();
        }

        public void CloseFile()
        {
            throw new NotImplementedException();
        }
    }
}
