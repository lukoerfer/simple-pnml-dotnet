using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a text at a specific position
    /// </summary>
    [XmlType]
    [Equals]
    public class Label
    {
        /// <summary>
        /// Gets or sets the text of this label
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("graphics")]
        public AnnotationGraphics Graphics { get; set; }

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <returns>A new label</returns>
        public Label() { }

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <param name="text">Any text</param>
        /// <returns>A new label</returns>
        public Label(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <param name="text">Any text</param>
        /// <param name="x">An absolute X coordinate</param>
        /// <param name="y">An absolute Y coordinate</param>
        /// <returns>A new label</returns>
        public Label(string text, int x, int y)
        {
            Text = text;
            Graphics = new AnnotationGraphics(x, y);
        }

    }
}
