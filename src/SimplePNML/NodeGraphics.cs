using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of a node element
    /// </summary>
    [Equals]
    [XmlType]
    public class NodeGraphics : ICollectable, IFilled, ILined, IDefaults
    {
        private Position position;
        private Size size;
        private Fill fill;
        private Line line;

        /// <summary>
        /// Gets or sets the position
        /// </summary>
        [XmlElement("position")]
        public Position Position
        {
            get => position ?? (position = new Position());
            set => position = value;
        }

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        [XmlElement("dimension")]
        public Size Size
        {
            get => size ?? (size = new Size());
            set => size = value;
        }

        /// <summary>
        /// Gets or sets the fill
        /// </summary>
        [XmlElement("fill")]
        public Fill Fill
        {
            get => fill ?? (fill = new Fill());
            set => fill = value;
        }

        /// <summary>
        /// Gets or sets the line
        /// </summary>
        [XmlElement("line")]
        public Line Line
        {
            get => line ?? (line = new Line());
            set => line = value;
        }


        /// <summary>
        /// Creates a new graphical node
        /// </summary>
        public NodeGraphics() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Position)
                .Include(Size)
                .Include(Fill)
                .Include(Line)
                .Collect();
        }

        public bool IsDefault()
        {
            return Position.IsDefault()
                && Size.IsDefault()
                && Fill.IsDefault()
                && Line.IsDefault();
        }

        #region Internal Serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSize() => !Size.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFill() => !Fill.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeLine() => !Line.IsDefault();

        #endregion
    }
}
