using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a graphical line element
    /// </summary>
    [Equals]
    [XmlType]
    public class Line
    {
        /// <summary>
        /// Gets or sets the color
        /// </summary>
        [XmlIgnore]
        public Color? Color { get; set; }

        #region Color Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("color")]
        public string ColorValue
        {
            get => ColorTranslator.ToHtml(Color.Value);
            set => Color = ColorTranslator.FromHtml(value);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeColorValue() => Color.HasValue;

        #endregion

        /// <summary>
        /// Gets or sets the width
        /// </summary>
        [XmlIgnore]
        public double? Width { get; set; }

        #region Width Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("width")]
        public double WidthValue
        {
            get => Width.Value;
            set => Width = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWidthValue() => Width.HasValue;

        #endregion

        /// <summary>
        /// Gets or sets the shape
        /// </summary>
        [XmlIgnore]
        public LineShape? Shape { get; set; }

        #region Shape Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("shape")]
        public LineShape ShapeValue
        {
            get => Shape.Value;
            set => Shape = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeShapeValue() => Shape.HasValue;

        #endregion

        /// <summary>
        /// Gets or sets the style
        /// </summary>
        [XmlIgnore]
        public LineStyle? Style { get; set; }

        #region Style Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("style")]
        public LineStyle StyleValue
        {
            get => Style.Value;
            set => Style = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeStyleValue() => Style.HasValue;

        #endregion

        /// <summary>
        /// Creates a new line
        /// </summary>
        public Line() { }

        /// <summary>
        /// Creates a new line
        /// </summary>
        /// <param name="color">A line color</param>
        /// <param name="width">An optional line width</param>
        /// <param name="shape">An optional line shape</param>
        /// <param name="style">An optional line style</param>
        public Line(Color color, double? width = null, LineShape? shape = null, LineStyle? style = null)
        {
            Color = color;
            Width = width;
            Shape = shape;
            Style = style;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Line WithColor(Color color)
        {
            Color = color;
            return this;
        }
    }
}
