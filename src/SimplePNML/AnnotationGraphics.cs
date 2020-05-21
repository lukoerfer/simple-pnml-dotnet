using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Offset offset;
        private Fill fill;
        private Line line;
        private Font font;

        /// <summary>
        /// Gets or sets the offset
        /// </summary>
        [XmlElement("offset")]
        public Offset Offset
        {
            get => offset ?? (offset = new Offset());
            set => offset = value;
        }

        /// <summary>
        /// Gets or sets the fill
        /// </summary>
        [XmlElement("fill")]
        public Fill Fill
        {
            get => fill ?? (fill = new Fill());
            set => fill = value;
        }

        /// <summary>
        /// Gets or sets the line
        /// </summary>
        [XmlElement("line")]
        public Line Line
        {
            get => line ?? (line = new Line());
            set => line = value;
        }

        /// <summary>
        /// Gets or sets the font
        /// </summary>
        [XmlElement("font")]
        public Font Font
        {
            get => font ?? (font = new Font());
            set => font = value;
        }

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
