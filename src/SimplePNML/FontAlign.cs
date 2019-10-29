using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    public enum FontAlign
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlEnum("left")]
        Left,
        /// <summary>
        /// 
        /// </summary>
        [XmlEnum("center")]
        Center,
        /// <summary>
        /// 
        /// </summary>
        [XmlEnum("right")]
        Right
    }
}
