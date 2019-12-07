using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of an edge element
    /// </summary>
    [Equals]
    [XmlType]
    public class Edge : ICollectable, ILined
    {
        /// <summary>
        /// Gets or sets the points of the edge
        /// </summary>
        [NotNull]
        [XmlElement("position")]
        public List<Position> Positions { get; set; } = new List<Position>();

        /// <summary>
        /// Gets or sets how to visualize the line
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; }

        /// <summary>
        /// Creates a new graphics description for an edge element
        /// </summary>
        public Edge() { }

        /// <summary>
        /// Creates a new graphics description for an edge element
        /// </summary>
        /// <param name="positions">Some points defining the graphical edge</param>
        public Edge(params Position[] positions)
        {
            Positions = new List<Position>(positions);
        }

        /// <summary>
        /// Creates a new graphics description for an edge element
        /// </summary>
        /// <param name="positions"></param>
        public Edge(params (double, double)[] positions)
        {
            Positions = positions.Select(position => new Position(position.Item1, position.Item2)).ToList();
        }

        /// <summary>
        /// Sets the points that define the edge
        /// </summary>
        /// <param name="positions">Some points that define the graphical edge</param>
        /// <returns>A reference to itself</returns>
        public Edge WithPositions(params Position[] positions)
        {
            Positions = positions.ToList();
            return this;
        }

        /// <summary>
        /// Sets the points that define the edge via tuples
        /// </summary>
        /// <param name="positions">Tuples descr</param>
        /// <returns>A reference to itself</returns>
        public Edge WithPositions(params (double, double)[] positions)
        {
            Positions = positions.Select(position => new Position(position.Item1, position.Item2)).ToList();
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return Collector.Create(this)
                .Collect(Positions)
                .Collect(Line)
                .Build();
        }
    }
}
