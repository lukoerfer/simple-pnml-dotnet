using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the fill of a graphical element
    /// </summary>
    [Equals]
    [XmlType]
    public class Fill : ICollectable
    {
        /// <summary>
        /// Gets or sets the fill color
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
        /// Gets or sets the gradient color
        /// </summary>
        [XmlIgnore]
        public Color? GradientColor { get; set; }

        #region GradientColor Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("gradient-color")]
        public string GradientColorValue
        {
            get => ColorTranslator.ToHtml(GradientColor.Value);
            set => GradientColor = ColorTranslator.FromHtml(value);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGradientColorValue() => GradientColor.HasValue;

        #endregion

        /// <summary>
        /// Gets or sets the gradient rotation
        /// </summary>
        [XmlIgnore]
        public GradientRotation? GradientRotation { get; set; }

        #region GradientRotation Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("gradient-rotation")]
        public GradientRotation GradientRotationValue
        {
            get => GradientRotation.Value;
            set => GradientRotation = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGradientRotationValue() => GradientRotation.HasValue;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public Uri Image { get; set; }

        #region Image Serialization

        [XmlAttribute("image")]
        public string ImageValue
        {
            get => Image?.ToString();
            set => Image = new Uri(value);
        }

        #endregion

        /// <summary>
        /// Creates a new fill
        /// </summary>
        public Fill() { }

        /// <summary>
        /// Creates a new fill
        /// </summary>
        /// <param name="color"></param>
        /// <param name="gradientColor"></param>
        /// <param name="gradientRotation"></param>
        public Fill(Color color, Color? gradientColor = null, GradientRotation? gradientRotation = null)
        {
            Color = color;
            GradientColor = gradientColor;
            GradientRotation = gradientRotation;
        }

        /// <summary>
        /// Creates a new fill
        /// </summary>
        /// <param name="image"></param>
        public Fill(Uri image)
        {
            Image = image;
        }

        public IEnumerable<ICollectable> Collect()
        {
            yield return this;
        }

    }
}
