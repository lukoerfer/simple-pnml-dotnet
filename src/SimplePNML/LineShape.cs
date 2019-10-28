using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Lists the possible line shapes
    /// </summary>
    public enum LineShape
    {
        /// <summary>
        /// Straight line
        /// </summary>
        [XmlEnum("line")]
        Line,
        /// <summary>
        /// Curved line
        /// </summary>
        [XmlEnum("curve")]
        Curve
    }
}
