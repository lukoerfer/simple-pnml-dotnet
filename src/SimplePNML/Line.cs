using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType]
    [Equals]
    public class Line
    {
        [XmlIgnore]
        public LineShape? Shape { get; set; }

        [XmlAttribute("shape")]
        public LineShape XmlShape
        {
            get => Shape.Value;
            set => Shape = value;
        }

        public bool ShouldSerializeXmlShape() => Shape.HasValue;

        [XmlIgnore]
        public Color? Color { get; set; }

        [XmlAttribute("color")]
        public string XmlColor
        {
            get => ColorTranslator.ToHtml(Color.Value);
            set => Color = ColorTranslator.FromHtml(value);
        }

        public bool ShouldSerializeXmlColor() => Color.HasValue;

        [XmlIgnore]
        public double? Width { get; set; }

        [XmlAttribute("width")]
        public double XmlWidth
        {
            get => Width.Value;
            set => Width = value;
        }

        public bool ShouldSerializeXmlWidth() => Width.HasValue;

        [XmlIgnore]
        public LineStyle? Style { get; set; }

        [XmlAttribute("style")]
        public LineStyle XmlStyle
        {
            get => Style.Value;
            set => Style = value;
        }

        public bool ShouldSerializeXmlStyle() => Style.HasValue;
    }
}
