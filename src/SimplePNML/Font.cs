using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [Equals]
    [XmlType]
    public class Font
    {
        /// <summary>
        /// Gets or sets the font family (CSS)
        /// </summary>
        [XmlAttribute("family")]
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the font style (CSS)
        /// </summary>
        [XmlAttribute("style")]
        public string Style { get; set; }

        /// <summary>
        /// Gets or sets the font weight (CSS)
        /// </summary>
        [XmlAttribute("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets the font size (CSS)
        /// </summary>
        [XmlAttribute("size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the font decoration
        /// </summary>
        [XmlIgnore]
        public FontDecoration? Decoration { get; set; }

        #region Decoration Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("decoration")]
        public FontDecoration DecorationValue
        {
            get => Decoration.Value;
            set => Decoration = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeDecorationValue() => Decoration.HasValue;

        #endregion

        /// <summary>
        /// Gets or sets the font alignment
        /// </summary>
        [XmlIgnore]
        public FontAlign? Align { get; set; }

        #region Align Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("align")]
        public FontAlign AlignValue
        {
            get => Align.Value;
            set => Align = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeAlignValue() => Align.HasValue;

        #endregion

        /// <summary>
        /// Gets or sets the rotation in degrees
        /// </summary>
        [XmlIgnore]
        public double? Rotation { get; set; }

        #region Rotation Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("rotation")]
        public double RotationValue
        {
            get => Rotation.Value;
            set => Rotation = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeRotationValue() => Rotation.HasValue;

        #endregion
    }
}
