using System.Collections.Generic;
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
        /// <summary>
        /// Implicitly creates a label from an integer value
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Label(int value) => new Label() { Text = value.ToString() };

        /// <summary>
        /// Implicitly creates a label from a double value
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Label(double value) => new Label() { Text = value.ToString() };

        /// <summary>
        /// Implicitly creates a label from a character string
        /// </summary>
        /// <param name="text"></param>
        public static implicit operator Label(string value) => new Label() { Text = value };

        /// <summary>
        /// Gets or sets the text of the label
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets how to visualize the label
        /// </summary>
        [XmlElement("graphics")]
        public AnnotationGraphics Graphics { get; set; }

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <returns>A new label</returns>
        public Label() { }

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

        public bool IsDefault()
        {
            return Text.IsEmpty() && Graphics.IsDefault();
        }
    }
}
