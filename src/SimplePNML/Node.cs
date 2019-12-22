using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of a node element
    /// </summary>
    [Equals]
    [XmlType]
    public class Node : ICollectable, IFilled, ILined
    {
        /// <summary>
        /// Gets or sets the position
        /// </summary>
        [NotNull]
        [XmlElement("position")]
        public Position Position { get; set; } = new Position();

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        [XmlElement("dimension")]
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets the fill
        /// </summary>
        [XmlElement("fill")]
        public Fill Fill { get; set; }

        /// <summary>
        /// Gets or sets the line
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; }

        /// <summary>
        /// Creates a new graphical node
        /// </summary>
        public Node() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return Collector.Create(this)
                .Collect(Position)
                .Collect(Size)
                .Collect(Fill)
                .Collect(Line)
                .Build();
        }
    }
}
