using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes dimension information (size) of a graphical element
    /// </summary>
    [Equals]
    [XmlType]
    public class Dimension
    {
        /// <summary>
        /// Gets or sets the length in X direction
        /// </summary>
        [XmlAttribute("x")]
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the length in Y direction
        /// </summary>
        [XmlAttribute("y")]
        public double Height { get; set; }

        /// <summary>
        /// Creates an empty dimension information
        /// </summary>
        public Dimension() { }

        /// <summary>
        /// Creates a new dimension information
        /// </summary>
        /// <param name="width">The length in X direction</param>
        /// <param name="height">The length in Y direction</param>
        public Dimension(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}
