using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a text at a specific position
    /// </summary>
    [Equals]
    [XmlType]
    public class Label : ICollectable, IAnnotation, IDefaults
    {
        private AnnotationGraphics graphics;

        /// <summary>
        /// Gets or sets the text of the label
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; } = "";

        /// <summary>
        /// Gets or sets how to visualize the label
        /// </summary>
        [XmlElement("graphics")]
        public AnnotationGraphics Graphics
        {
            get => graphics ?? (graphics = new AnnotationGraphics());
            set => graphics = value;
        }

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <returns>A new label</returns>
        public Label() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public Label(string text)
        {
            Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Graphics)
                .Collect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsDefault()
        {
            return Text.IsEmpty()
                && Graphics.IsDefault();
        }

        #region Internal serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGraphics() => !Graphics.IsDefault();

        #endregion
    }
}
