using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SimplePNML
{
    public enum LineShape
    {
        [XmlEnum("line")]
        Line,
        [XmlEnum("curve")]
        Curve
    }
}
