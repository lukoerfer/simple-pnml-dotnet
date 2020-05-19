using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Defines the supported line shapes
    /// </summary>
    public enum LineShape
    {
        /// <summary>
        /// Straight line
        /// </summary>
        [XmlEnum("line")]
        Line = 0,
        /// <summary>
        /// Curved line
        /// </summary>
        [XmlEnum("curve")]
        Curve = 1
    }
}
