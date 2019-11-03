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
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the length in Y direction
        /// </summary>
        [XmlAttribute("y")]
        public double Y { get; set; }

        /// <summary>
        /// Creates a new dimension information
        /// </summary>
        public Dimension() { }

        /// <summary>
        /// Creates a new dimension information
        /// </summary>
        /// <param name="x">The length in X direction</param>
        /// <param name="y">The length in Y direction</param>
        public Dimension(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
