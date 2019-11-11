﻿using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a text at a specific position
    /// </summary>
    [Equals]
    [XmlType]
    public class Label : IAnnotationElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Label(int value) => new Label(value.ToString());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Label(double value) => new Label(value.ToString());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static implicit operator Label(string text) => new Label(text);

        /// <summary>
        /// Gets or sets the text of the label
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets how to visualize the label
        /// </summary>
        [XmlElement("graphics")]
        public Annotation Graphics { get; set; }

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <returns>A new label</returns>
        public Label() { }

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <param name="text">Any text</param>
        /// <returns>A new label</returns>
        public Label(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <param name="text">The label text</param>
        /// <param name="x">The offset in X direction</param>
        /// <param name="y">The offset in Y direction</param>
        /// <param name="fill">An optional fill</param>
        /// <param name="line">An optional line</param>
        /// <param name="font">An optional font</param>
        /// <returns>A new label</returns>
        public Label(string text, int x, int y, Fill fill = null, Line line = null, Font font = null)
        {
            Text = text;
            Graphics = new Annotation(x, y, fill, line, font);
        }

        /// <summary>
        /// Sets the text of the label
        /// </summary>
        /// <param name="text">The label text</param>
        /// <returns>A reference to itself</returns>
        public Label WithText(string text)
        {
            Text = text;
            return this;
        }

        /// <summary>
        /// Sets the position of the label
        /// </summary>
        /// <param name="x">The offset in X direction</param>
        /// <param name="y">The offset in X direction</param>
        /// <returns>A reference to itself</returns>
        public Label AtPosition(int x, int y)
        {
            if (Graphics != null)
            {
                Graphics.Offset = new Coordinates(x, y);
            }
            else
            {
                Graphics = new Annotation(x, y);
            }
            return this;
        }

        /// <summary>
        /// Defines how to visualize the label
        /// </summary>
        /// <param name="graphics">The description how to visualize the label</param>
        /// <returns>A reference to itself</returns>
        public Label WithGraphics(Annotation graphics)
        {
            Graphics = graphics;
            return this;
        }

        /// <summary>
        /// Defines how to visualize the label
        /// </summary>
        /// <param name="x">The offset in X direction</param>
        /// <param name="y">The offset in Y direction</param>
        /// <param name="fill">An optional fill</param>
        /// <param name="line">An optional line</param>
        /// <param name="font">An optional font</param>
        /// <returns>A reference to itself</returns>
        public Label WithGraphics(int x, int y, Fill fill = null, Line line = null, Font font = null)
        {
            Graphics = new Annotation(x, y, fill, line, font);
            return this;
        }
    }
}
