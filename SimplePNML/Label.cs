using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a text at a specific position
    /// </summary>
    public class Label
    {
        /// <summary>
        /// Gets or sets the text of this label
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets position information for this label
        /// </summary>
        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }

        /// <summary>
        /// Creates a label at an absolute position
        /// </summary>
        /// <param name="x">An absolute X coordinate</param>
        /// <param name="y">An absolute Y coordinate</param>
        /// <param name="text">Any text</param>
        /// <returns>A new label</returns>
        public static Label Absolute(int x, int y, string text)
        {
            return new Label()
            {
                Text = text,
                Graphics = Graphics.Absolute(x, y)
            };
        }

        /// <summary>
        /// Creates a label at a relative position
        /// </summary>
        /// <param name="x">A relative X coordinate</param>
        /// <param name="y">A relative Y coordinate</param>
        /// <param name="text">Any text</param>
        /// <returns>A new label</returns>
        public static Label Relative(int x, int y, string text)
        {
            return new Label()
            {
                Text = text,
                Graphics = Graphics.Relative(x, y)
            };
        }

    }
}
