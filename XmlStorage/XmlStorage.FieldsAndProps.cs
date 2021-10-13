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
        private XDocument xdoc;
        public  XDocument Xdoc
        {
            get { return xdoc; }
            set { xdoc = value; }
        }

        private string xDocSource;
        public  string XDocSource
        {
            get { return xDocSource; }
            set { xDocSource = value; }
        }
        
    }
}
