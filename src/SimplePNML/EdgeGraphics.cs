using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of an edge element
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class EdgeGraphics : ICollectable, ILined, IDefaultable
    {
        private List<Position> positions = new List<Position>();

        /// <summary>
        /// Gets or sets the points of the edge
        /// </summary>
        [XmlElement("position")]
        public List<Position> Positions
        {
            get => positions;
            set => positions = new List<Position>(value);
        }

        /// <summary>
        /// Gets or sets how to visualize the line
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; } = new Line();

        /// <summary>
        /// Creates a new graphics description for an edge element
        /// </summary>
        public EdgeGraphics() { }

        /// <summary>
        /// Collects all child elements of this edge recursively
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Positions)
                .Include(Line)
                .Collect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsDefault()
        {
            return Line.IsDefault()
                && Positions.Count == 0;
        }

        #region Internal serialization

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeLine() => !Line.IsDefault();

        #endregion
    }
}
