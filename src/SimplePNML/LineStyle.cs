using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Defines the supported line styles
    /// </summary>
    public enum LineStyle
    {
        /// <summary>
        /// Solid line
        /// </summary>
        [XmlEnum("solid")]
        Solid = 0,
        /// <summary>
        /// Dashed line
        /// </summary>
        [XmlEnum("dash")]
        Dash = 1,
        /// <summary>
        /// Dotted line
        /// </summary>
        [XmlEnum("dot")]
        Dot = 2
    }
}
