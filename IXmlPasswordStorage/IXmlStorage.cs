using System;
using System.Collections;

namespace SeemObject
{
    public interface IXmlStorage
    {
        public void SetXmlSource(string source);
        public void GetFileFromSource();
        public void OpenAsXml();
        public void OpenAsFile();
        public void CloseXml();
        public void CloseFile();
        
    }
}
