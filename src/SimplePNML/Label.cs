using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a text at a specific position
    /// </summary>
    [Equals]
    [XmlType]
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
        public Annotation Graphics { get; set; }

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
            Graphics = new Annotation(x, y, fill, line, font);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Label WithText(string text)
        {
            Text = text;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Label AtPosition(int x, int y)
        {
            Graphics = new Annotation(x, y);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <returns></returns>
        public Label WithGraphics(Annotation graphics)
        {
            Graphics = graphics;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public Label WithGraphics(int x, int y, Fill fill = null, Line line = null, Font font = null)
        {
            Graphics = new Annotation(x, y, fill, line, font);
            return this;
        }
    }
}
