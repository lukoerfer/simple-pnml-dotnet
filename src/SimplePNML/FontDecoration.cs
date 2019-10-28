using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    public enum FontDecoration
    {
        [XmlEnum("underline")]
        Underline,
        [XmlEnum("overline")]
        Overline,
        [XmlEnum("line-through")]
        LineThrough

    }
}
