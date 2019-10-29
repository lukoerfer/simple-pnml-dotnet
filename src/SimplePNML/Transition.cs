using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML transition
    /// </summary>
    [Equals]
    [XmlType("transition")]
    public class Transition : IConnectable
    {
        /// <summary>
        /// Gets or sets the identifier of this transition
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a label containing the name
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("graphics")]
        public Node Graphics { get; set; }

        /// <summary>
        /// Creates a new transition
        /// </summary>
        public Transition() : this(null, null, null) { }

        /// <summary>
        /// Creates a new transition
        /// </summary>
        /// <param name="name"></param>
        /// <param name="graphics"></param>
        public Transition(Label name, Node graphics = null) : this(null, name, graphics) { }

        /// <summary>
        /// Creates a new transition
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="graphics"></param>
        public Transition(string id, Label name = null, Node graphics = null)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            Name = name;
            Graphics = graphics;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Transition WithName(string name)
        {
            Name = new Label(name);
            return this;
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
        /// <param name="graphics"></param>
        /// <returns></returns>
        public Transition WithGraphics(Node graphics)
        {
            Graphics = graphics;
            return this;
        }
    }
}
