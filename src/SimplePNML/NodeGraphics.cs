using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of a node element
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class NodeGraphics : ICollectable, IFilled, ILined, IDefaultable
    {
        /// <summary>
        /// Gets or sets the position
        /// </summary>
        [XmlElement("position")]
        public Position Position { get; set; } = new Position();

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        [XmlElement("dimension")]
        public Size Size { get; set; } = new Size();

        /// <summary>
        /// Gets or sets the fill
        /// </summary>
        [XmlElement("fill")]
        public Fill Fill { get; set; } = new Fill();

        /// <summary>
        /// Gets or sets the line
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; } = new Line();


        /// <summary>
        /// Creates a new graphical node
        /// </summary>
        public NodeGraphics() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Position)
                .Include(Size)
                .Include(Fill)
                .Include(Line)
                .Collect();
        }

        public bool IsDefault()
        {
            return Position.IsDefault()
                && Size.IsDefault()
                && Fill.IsDefault()
                && Line.IsDefault();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSize() => !Size.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFill() => !Fill.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeLine() => !Line.IsDefault();

    }
}
