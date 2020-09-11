using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the fill of a graphical element
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class Fill : ICollectable, IDefaultable
    {
        /// <summary>
        /// Gets or sets the fill color
        /// </summary>
        [XmlAttribute("color")]
        public string Color { get; set; } = "";

        /// <summary>
        /// Gets or sets the gradient color
        /// </summary>
        [XmlAttribute("gradient-color")]
        public string GradientColor { get; set; } = "";

        /// <summary>
        /// Gets or sets the gradient rotation
        /// </summary>
        [XmlAttribute("gradient-rotation")]
        public GradientRotation GradientRotation { get; set; } = GradientRotation.None;

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("image")]
        public string Image { get; set; } = "";

        /// <summary>
        /// Creates a new fill
        /// </summary>
        public Fill() { }

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
            return Color.IsEmpty()
                && GradientColor.IsEmpty()
                && GradientRotation.IsDefault()
                && Image.IsEmpty();
        }

        #region Internal serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeColor() => !Color.IsEmpty();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGradientColor() => !GradientColor.IsEmpty();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGradientRotation() => !GradientRotation.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeImage() => !Image.IsEmpty();

        #endregion
    }
}
