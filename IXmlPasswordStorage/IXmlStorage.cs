using System;
using System.Collections;

namespace SeemObject
{
    public partial interface IXmlStorage
    {
        public void SetXDocSource(string source);
        public object GetXDoc();
        

    }
}
