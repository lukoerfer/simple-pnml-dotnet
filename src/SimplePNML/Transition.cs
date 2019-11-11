using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML transition
    /// </summary>
    [Equals]
    [XmlType("transition")]
    public class Transition : Connectable, INodeElement
    {
        /// <summary>
        /// Gets or sets a label containing the name
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets the transition graphics
        /// </summary>
        [XmlElement("graphics")]
        public Node Graphics { get; set; }

        /// <summary>
        /// Creates a new transition with a generated ID
        /// </summary>
        public Transition() : this(null) { }

        /// <summary>
        /// Creates a new transition with a given ID
        /// </summary>
        /// <param name="id"></param>
        public Transition(string id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Transition WithName(Label name)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphic"></param>
        /// <returns>A reference to itself</returns>
        public Transition WithGraphics(Node graphics)
        {
            Graphics = graphics;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        /// <returns>A reference to itself</returns>
        public Transition WithGraphics(double x, double y, Fill fill = null, Line line = null)
        {
            Graphics = new Node(x, y, fill, line);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        /// <returns>A reference to itself</returns>
        public Transition WithGraphics(double x, double y, double width, double height, Fill fill = null, Line line = null)
        {
            Graphics = new Node(x, y, width, height, fill, line);
            return this;
        }
    }
}
