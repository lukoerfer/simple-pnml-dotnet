using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Specifies a font in PNML
    /// </summary>
    [Equals]
    [XmlType]
    public class Font : ICollectable
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

        /// <summary>
        /// Serializes or deserializes the font decoration value
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("decoration")]
        public FontDecoration DecorationValue
        {
            get => Decoration.Value;
            set => Decoration = value;
        }

        /// <summary>
        /// Defines whether the font decoration should be serialized
        /// </summary>
        /// <returns>True if the font decoration should be serialized, false if not</returns>
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

        /// <summary>
        /// Serializes or deserializes the font alignment value
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("align")]
        public FontAlign AlignValue
        {
            get => Align.Value;
            set => Align = value;
        }

        /// <summary>
        /// Defines whether the font alignment should be serialized
        /// </summary>
        /// <returns>True if the font alignment should be serialized, false if not</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeAlignValue() => Align.HasValue;

        #endregion

        /// <summary>
        /// Gets or sets the font rotation in degrees
        /// </summary>
        [XmlIgnore]
        public double? Rotation { get; set; }

        #region Rotation Serialization

        /// <summary>
        /// Serializes or deserializes the font rotation value
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("rotation")]
        public double RotationValue
        {
            get => Rotation.Value;
            set => Rotation = value;
        }

        /// <summary>
        /// Defines whether the font rotation should be serialized
        /// </summary>
        /// <returns>True if the font rotation should be serialized, false if not</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeRotationValue() => Rotation.HasValue;

        #endregion

        /// <summary>
        /// Creates a new font
        /// </summary>
        public Font() { }

        /// <summary>
        /// Creates a new font
        /// </summary>
        /// <param name="family">The font family, can be null</param>
        /// <param name="style">An optional font style (CSS)</param>
        /// <param name="weight">An optional font weight (CSS)</param>
        /// <param name="size">An optional font size (CSS)</param>
        /// <param name="decoration">An optional font decoration</param>
        /// <param name="align">An optional font alignment</param>
        /// <param name="rotation">An optional font rotation</param>
        public Font(string family, string style = null, string weight = null, string size = null, 
            FontDecoration? decoration = null, FontAlign? align = null, double? rotation = null)
        {
            Family = family;
            Style = style;
            Weight = weight;
            Size = size;
            Decoration = decoration;
            Align = align;
            Rotation = rotation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            yield return this;
        }
    }
}
