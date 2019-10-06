using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [XmlType]
    [Equals]
    public class NodeGraphics
    {
        /// <summary>
        /// Gets or sets the position
        /// </summary>
        [XmlElement("position")]
        public Coordinates Position { get; set; } = new Coordinates();

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("dimension")]
        public Dimension Dimension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("fill")]
        public Fill Fill { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; }

        /// <summary>
        /// Creates a new graphics information
        /// </summary>
        public NodeGraphics() { }

        /// <summary>
        /// Creates a new graphics information
        /// </summary>
        /// <param name="x">An absolute X coordinate</param>
        /// <param name="y">An absolute Y coordinate</param>
        public NodeGraphics(int x, int y)
        {
            Position = new Coordinates(x, y);
        }

        /// <summary>
        /// Creates a new graphics information
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public NodeGraphics(int x, int y, int width, int height)
        {
            Position = new Coordinates(x, y);
            Dimension = new Dimension(width, height);
        }

    }
}
