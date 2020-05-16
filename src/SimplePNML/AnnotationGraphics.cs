using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of an annotation element
    /// </summary>
    [Equals]
    [XmlType]
    public class AnnotationGraphics : ICollectable, IFilled, ILined, IDefaults
    {
        /// <summary>
        /// Gets or sets the offset
        /// </summary>
        [XmlElement("offset")]
        public Offset Offset { get; set; } = new Offset();

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
        /// Gets or sets the font
        /// </summary>
        [XmlElement("font")]
        public Font Font { get; set; }

        /// <summary>
        /// Creates a new graphical annotation
        /// </summary>
        public AnnotationGraphics() { }

        /// <summary>
        /// Collects the child elements of this annotation recursively
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Offset)
                .Include(Fill)
                .Include(Line)
                .Include(Font)
                .Collect();
        }

        public bool IsDefault() => Offset.IsDefault() && Fill.IsDefault() && Line.IsDefault() && Font.IsDefault();
    }
}
