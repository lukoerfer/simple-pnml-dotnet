using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    public enum GradientRotation
    {
        /// <summary>
        /// Vertical rotation
        /// </summary>
        [XmlEnum("vertical")]
        Vertical,
        /// <summary>
        /// Horizontal rotation
        /// </summary>
        [XmlEnum("horizontal")]
        Horizontal,
        /// <summary>
        /// Diagonal rotation
        /// </summary>
        [XmlEnum("diagonal")]
        Diagonal
    }
}
