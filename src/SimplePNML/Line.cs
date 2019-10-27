using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [Equals]
    [XmlType]
    public class Line
    {
        /// <summary>
        /// 
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
        /// 
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
        /// 
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
        /// 
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
    }
}
