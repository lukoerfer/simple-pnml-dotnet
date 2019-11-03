using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a text at a specific position
    /// </summary>
    [Equals]
    [XmlType]
    public class Label : IAnnotationElement
    {
        /// <summary>
        /// Gets or sets the text of the label
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets how to visualize the label
        /// </summary>
        [XmlElement("graphics")]
        public Annotation Graphic { get; set; }

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
        /// <param name="x">A relative X coordinate</param>
        /// <param name="y">A relative Y coordinate</param>
        /// <returns>A new label</returns>
        public Label(string text, int x, int y, Fill fill = null, Line line = null, Font font = null)
        {
            Text = text;
            Graphic = new Annotation(x, y, fill, line, font);
        }

        /// <summary>
        /// Sets the text of the label
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A reference to itself</returns>
        public Label WithText(string text)
        {
            Text = text;
            return this;
        }

        /// <summary>
        /// Sets the position of the label
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>A reference to itself</returns>
        public Label AtPosition(int x, int y)
        {
            Graphic = new Annotation(x, y);
            return this;
        }

        /// <summary>
        /// Sets how to visualize the label
        /// </summary>
        /// <param name="graphics"></param>
        /// <returns>A reference to itself</returns>
        public Label WithGraphics(Annotation graphics)
        {
            Graphic = graphics;
            return this;
        }

        /// <summary>
        /// Sets how to visualize the label
        /// </summary>
        /// <param name="x">The offset in X direction</param>
        /// <param name="y">The offset in Y direction</param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public Label WithGraphics(int x, int y, Fill fill = null, Line line = null, Font font = null)
        {
            Graphic = new Annotation(x, y, fill, line, font);
            return this;
        }
    }
}
