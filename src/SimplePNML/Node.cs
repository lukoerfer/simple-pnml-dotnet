using System;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [Equals]
    [XmlType]
    public class Node
    {
        /// <summary>
        /// Gets or sets the position
        /// </summary>
        [XmlElement("position")]
        public Coordinates Position { get; set; } = new Coordinates();

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        [XmlElement("dimension")]
        public Dimension Size { get; set; }

        /// <summary>
        /// Gets or sets the fill visualization
        /// </summary>
        [XmlElement("fill")]
        public Fill Fill { get; set; }

        /// <summary>
        /// Gets or sets the line visualization
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; }

        /// <summary>
        /// Creates a new graphics information
        /// </summary>
        public Node() { }

        /// <summary>
        /// Creates a new graphical node
        /// </summary>
        /// <param name="x">An absolute X coordinate</param>
        /// <param name="y">An absolute Y coordinate</param>
        public Node(int x, int y)
        {
            Position = new Coordinates(x, y);
        }

        /// <summary>
        /// Creates a new graphics information
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Node(int x, int y, int width, int height)
        {
            Position = new Coordinates(x, y);
            Size = new Dimension(width, height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Node AtPosition(int x, int y)
        {
            return new Node(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Node WithSize(int width, int height)
        {
            Size = new Dimension(width, height);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="gradientColor"></param>
        /// <param name="gradientRotation"></param>
        /// <returns></returns>
        public Node WithFill(Color color, Color? gradientColor = null, GradientRotation? gradientRotation = null)
        {
            Fill = new Fill(color, gradientColor, gradientRotation);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Node WithFill(Uri image)
        {
            Fill = new Fill(image);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="shape"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public Node WithLine(Color color, double? width = null, LineShape? shape = null, LineStyle? style = null)
        {
            Line = new Line(color, width, shape, style);
            return this;
        }

    }
}
