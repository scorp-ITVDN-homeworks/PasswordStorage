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
        private XmlTextReader reader;
        public  XmlTextReader Reader
        {
            get { return reader; }
            set { reader = value; }
        }

        private string xmlSource;
        public  string XmlSource
        {
            get { return xmlSource; }
            set { xmlSource = value; }
        }

        private FileInfo xmlSourceFile;
        public FileInfo XmlSourceFile
        {
            get { return xmlSourceFile; }
            set { xmlSourceFile = value; }
        }
    }
}
