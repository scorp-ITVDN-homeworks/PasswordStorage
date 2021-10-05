using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.Model
{
    public class XmlStorageAttribute : Attribute
    {
        public XmlStorageAttribute(Element elementType, string parent, string nodeName)
        {
            ElementType = elementType;
            Parent = parent;
            NodeName = nodeName;
        }

        public XmlStorageAttribute(Element elementType, string parent, string nodeName, string attributeName)
        {
            ElementType = elementType;
            Parent = parent;
            NodeName = nodeName;
            AttributeName = attributeName;
        }

        public string Parent
        {
            get; set;
        }

        public string NodeName
        {
            get; set;
        }

        public string AttributeName
        {
            get; set;
        }

        public Element ElementType
        {
            get; set;
        }

        public enum Element
        {
            Node,
            Attribute
        }

        public bool IsVoidAttributeName
        {
            get { if (AttributeName == null) return true; else return false; }
        }
    }
}
