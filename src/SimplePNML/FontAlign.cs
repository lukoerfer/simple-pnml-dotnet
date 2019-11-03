using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Defines the supported font alignments
    /// </summary>
    public enum FontAlign
    {
        /// <summary>
        /// Align left
        /// </summary>
        [XmlEnum("left")]
        Left,
        /// <summary>
        /// Align centered
        /// </summary>
        [XmlEnum("center")]
        Center,
        /// <summary>
        /// Align right
        /// </summary>
        [XmlEnum("right")]
        Right
    }
}
