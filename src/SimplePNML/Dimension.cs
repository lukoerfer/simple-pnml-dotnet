using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
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
        /// Creates an empty set of coordinates
        /// </summary>
        public Dimension() { }

        /// <summary>
        /// Creates a new set of coordinates
        /// </summary>
        /// <param name="x">Any value for the X direction</param>
        /// <param name="y">Any value for the Y direction</param>
        public Dimension(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
