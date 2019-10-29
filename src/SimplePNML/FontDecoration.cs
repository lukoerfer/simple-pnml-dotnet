using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    public enum FontDecoration
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlEnum("underline")]
        Underline,
        /// <summary>
        /// 
        /// </summary>
        [XmlEnum("overline")]
        Overline,
        /// <summary>
        /// 
        /// </summary>
        [XmlEnum("line-through")]
        LineThrough

    }
}
