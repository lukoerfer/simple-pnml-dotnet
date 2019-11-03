using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Defines the supported font decorations
    /// </summary>
    public enum FontDecoration
    {
        /// <summary>
        /// Underlined text
        /// </summary>
        [XmlEnum("underline")]
        Underline,
        /// <summary>
        /// Overlined text
        /// </summary>
        [XmlEnum("overline")]
        Overline,
        /// <summary>
        /// Strikethrough text
        /// </summary>
        [XmlEnum("line-through")]
        LineThrough

    }
}
