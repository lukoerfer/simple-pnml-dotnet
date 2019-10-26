using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    [Equals]
    [XmlType]
    public class Line
    {
        [XmlIgnore]
        public LineShape? Shape { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("shape")]
        public LineShape XmlShape
        {
            get => Shape.Value;
            set => Shape = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeXmlShape() => Shape.HasValue;

        [XmlIgnore]
        public Color? Color { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("color")]
        public string XmlColor
        {
            get => ColorTranslator.ToHtml(Color.Value);
            set => Color = ColorTranslator.FromHtml(value);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeXmlColor() => Color.HasValue;

        [XmlIgnore]
        public double? Width { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("width")]
        public double XmlWidth
        {
            get => Width.Value;
            set => Width = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeXmlWidth() => Width.HasValue;

        [XmlIgnore]
        public LineStyle? Style { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("style")]
        public LineStyle XmlStyle
        {
            get => Style.Value;
            set => Style = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeXmlStyle() => Style.HasValue;
    }
}
