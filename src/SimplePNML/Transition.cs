using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML transition
    /// </summary>
    [Equals]
    [XmlType("transition")]
    public class Transition : Connectable, ICollectable, INamed, INode, IToolExtendable
    {
        /// <summary>
        /// Gets or sets the name 
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets the graphics
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphics { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ToolSpecific> ToolSpecificData { get; set; } = new List<ToolSpecific>();

        /// <summary>
        /// Creates a new transition with a generated ID
        /// </summary>
        public Transition() : base() { }

        /// <summary>
        /// Creates a new transition
        /// </summary>
        /// <param name="id"></param>
        public Transition(string id) : base(id) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Name)
                .Include(Graphics)
                .Include(ToolSpecificData)
                .Collect();
        }
    }
}
