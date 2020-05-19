using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Defines the supported font decorations
    /// </summary>
    public enum FontDecoration
    {
        None = 0,
        /// <summary>
        /// Underlined text
        /// </summary>
        [XmlEnum("underline")]
        Underline = 1,
        /// <summary>
        /// Overlined text
        /// </summary>
        [XmlEnum("overline")]
        Overline = 2,
        /// <summary>
        /// Strikethrough text
        /// </summary>
        [XmlEnum("line-through")]
        LineThrough = 3
    }
}
