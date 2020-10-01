using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Specifies a font in PNML
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class Font : ICollectable, IDefaultable
    {
        /// <summary>
        /// Gets or sets the font family (CSS)
        /// </summary>
        [XmlAttribute("family")]
        public string Family { get; set; } = "";

        /// <summary>
        /// Gets or sets the font style (CSS)
        /// </summary>
        [XmlAttribute("style")]
        public string Style { get; set; } = "";

        /// <summary>
        /// Gets or sets the font weight (CSS)
        /// </summary>
        [XmlAttribute("weight")]
        public string Weight { get; set; } = "";

        /// <summary>
        /// Gets or sets the font size (CSS)
        /// </summary>
        [XmlAttribute("size")]
        public string Size { get; set; } = "";

        /// <summary>
        /// Gets or sets the font decoration
        /// </summary>
        [XmlAttribute("decoration")]
        public FontDecoration Decoration { get; set; } = FontDecoration.None;

        /// <summary>
        /// Gets or sets the font alignment
        /// </summary>
        [XmlAttribute("align")]
        public FontAlign Align { get; set; } = FontAlign.Left;

        /// <summary>
        /// Gets or sets the font rotation in degrees
        /// </summary>
        [XmlAttribute("rotation")]
        public double Rotation { get; set; } = 0.0;

        /// <summary>
        /// Creates a new font
        /// </summary>
        public Font() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            yield return this;
        }

        public bool IsDefault()
        {
            return Family.IsEmpty()
                && Style.IsEmpty()
                && Weight.IsEmpty()
                && Size.IsEmpty()
                && Decoration.IsDefault()
                && Align.IsDefault()
                && Rotation == 0.0;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFamily() => !Family.IsEmpty();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeStyle() => !Style.IsEmpty();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWeight() => !Weight.IsEmpty();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSize() => !Size.IsEmpty();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeDecoration() => !Decoration.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeAlign() => !Align.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeRotation() => Rotation != 0.0;

    }
}
