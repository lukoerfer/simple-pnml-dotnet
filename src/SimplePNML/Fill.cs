using System;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [XmlType]
    [Equals]
    public class Fill
    {
        /// <summary>
        /// 
        /// </summary>
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
        public Color? GradientColor { get; set; }

        [XmlAttribute("gradient-color")]
        public string XmlGradientColor
        {
            get => ColorTranslator.ToHtml(GradientColor.Value);
            set => GradientColor = ColorTranslator.FromHtml(value);
        }

        public bool ShouldSerializeXmlGradientColor() => GradientColor.HasValue;

        [XmlIgnore]
        public Gradient? GradientRotation { get; set; }

        [XmlAttribute("gradient-rotation")]
        public Gradient XmlGradientRotation
        {
            get => GradientRotation.Value;
            set => GradientRotation = value;
        }

        public bool ShouldSerializeXmlGradientRotation() => GradientRotation.HasValue;

        [XmlIgnore]
        public Uri Image { get; set; }

        [XmlAttribute("image")]
        public string XmlImage
        {
            get => Image.ToString();
            set => Image = new Uri(value);
        }

        public Fill() { }

        public Fill(Color? color, Color? gradient = null, Gradient? rotation = null)
        {
            Color = color;
            GradientColor = gradient;
            GradientRotation = rotation;
        }

        public Fill(Uri image)
        {
            Image = image;
        }

    }
}
