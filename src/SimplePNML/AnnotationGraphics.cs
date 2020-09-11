using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphical representation of an annotation element
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class AnnotationGraphics : ICollectable, IFilled, ILined, IDefaultable
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
        public Fill Fill { get; set; } = new Fill();

        /// <summary>
        /// Gets or sets the line
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; } = new Line();

        /// <summary>
        /// Gets or sets the font
        /// </summary>
        [XmlElement("font")]
        public Font Font { get; set; } = new Font();

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsDefault()
        {
            return Offset.IsDefault()
                && Fill.IsDefault()
                && Line.IsDefault()
                && Font.IsDefault();
        }

        #region Internal serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeOffset() => !Offset.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFill() => !Fill.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeLine() => !Line.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFont() => !Font.IsDefault();

        #endregion
    }
}
