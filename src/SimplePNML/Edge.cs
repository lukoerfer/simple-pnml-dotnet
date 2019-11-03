using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of an edge element
    /// </summary>
    [Equals]
    [XmlType]
    public class Edge
    {
        /// <summary>
        /// Gets or sets the points of the edge
        /// </summary>
        [XmlElement("position")]
        public List<Coordinates> Positions { get; set; } = new List<Coordinates>();

        /// <summary>
        /// Gets or sets how to visualize the line
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; }

        /// <summary>
        /// Creates a new graphical edge
        /// </summary>
        public Edge() { }

        /// <summary>
        /// Creates a new graphical edge
        /// </summary>
        /// <param name="positions"></param>
        public Edge(params Coordinates[] positions)
        {
            Positions = new List<Coordinates>(positions);
        }

        /// <summary>
        /// Sets the points that define the edge
        /// </summary>
        /// <param name="positions"></param>
        /// <returns>A reference to itself</returns>
        public Edge WithPositions(params Coordinates[] positions)
        {
            Positions.AddRange(positions);
            return this;
        }

        /// <summary>
        /// Sets how to visualize the line of the edge
        /// </summary>
        /// <param name="line"></param>
        /// <returns>A reference to itself</returns>
        public Edge WithLine(Line line)
        {
            Line = line;
            return this;
        }

        /// <summary>
        /// Sets how to visualize the line of the edge
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="shape"></param>
        /// <param name="style"></param>
        /// <returns>A reference to itself</returns>
        public Edge WithLine(Color color, double? width = null, LineShape? shape = null, LineStyle? style = null)
        {
            Line = new Line(color, width, shape, style);
            return this;
        }

    }
}
