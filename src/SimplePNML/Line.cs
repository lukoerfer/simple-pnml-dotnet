using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a graphical line element
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class Line : ICollectable, IDefaultable
    {
        /// <summary>
        /// Gets or sets the color
        /// </summary>
        [XmlAttribute("color")]
        public string Color { get; set; } = "";

        /// <summary>
        /// Gets or sets the width
        /// </summary>
        [XmlAttribute("width")]
        public double Width { get; set; } = 0.0;

        /// <summary>
        /// Gets or sets the shape
        /// </summary>
        [XmlAttribute("shape")]
        public LineShape Shape { get; set; } = LineShape.Line;

        /// <summary>
        /// Gets or sets the style
        /// </summary>
        [XmlAttribute("style")]
        public LineStyle Style { get; set; } = LineStyle.Solid;

        /// <summary>
        /// Creates a new line
        /// </summary>
        public Line() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            yield return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsDefault()
        {
            return Color.IsEmpty()
                && Width == 0.0
                && Shape.IsDefault()
                && Style.IsDefault();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeColor() => !Color.IsEmpty();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWidth() => Width != 0.0;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeShape() => !Shape.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeStyle() => !Style.IsDefault();

    }
}
