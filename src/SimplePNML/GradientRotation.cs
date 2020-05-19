using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Defines the supported gradient rotations
    /// </summary>
    public enum GradientRotation
    {
        None = 0,
        /// <summary>
        /// Vertical rotation
        /// </summary>
        [XmlEnum("vertical")]
        Vertical = 1,
        /// <summary>
        /// Horizontal rotation
        /// </summary>
        [XmlEnum("horizontal")]
        Horizontal = 2,
        /// <summary>
        /// Diagonal rotation
        /// </summary>
        [XmlEnum("diagonal")]
        Diagonal = 3
    }
}
