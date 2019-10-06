using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [XmlType]
    [Equals]
    public class Font
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("family")]
        public string Family { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("style")]
        public string Style { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("size")]
        public string Size { get; set; }

        [XmlIgnore]
        public FontDecoration? Decoration { get; set; }

        [XmlAttribute("decoration")]
        public FontDecoration XmlDecoration
        {
            get => Decoration.Value;
            set => Decoration = value;
        }

        public bool ShouldSerializeXmlDecoration() => Decoration.HasValue;

        [XmlIgnore]
        public FontAlign? Align { get; set; }

        [XmlAttribute("align")]
        public FontAlign XmlAlign
        {
            get => Align.Value;
            set => Align = value;
        }

        public bool ShouldSerializeXmlAlign() => Align.HasValue;

        [XmlIgnore]
        public double? Rotation { get; set; }

        [XmlAttribute("rotation")]
        public double XmlRotation
        {
            get => Rotation.Value;
            set => Rotation = value;
        }

        public bool ShouldSerializeXmlRotation() => Rotation.HasValue;
    }
}
