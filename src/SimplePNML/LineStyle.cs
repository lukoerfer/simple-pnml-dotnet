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
        Solid,
        /// <summary>
        /// Dashed line
        /// </summary>
        [XmlEnum("dash")]
        Dash,
        /// <summary>
        /// Dotted line
        /// </summary>
        [XmlEnum("dot")]
        Dot
    }
}
