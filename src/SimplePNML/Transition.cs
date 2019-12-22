using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML transition
    /// </summary>
    [Equals]
    [XmlType("transition")]
    public class Transition : Connectable, ICollectable, INamed, INodeElement
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
        public Node Graphics { get; set; }

        /// <summary>
        /// Creates a new transition with a generated ID
        /// </summary>
        public Transition() : this(null) { }

        /// <summary>
        /// Creates a new transition
        /// </summary>
        /// <param name="id"></param>
        public Transition(string id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return Collector.Create(this)
                .Collect(Name)
                .Collect(Graphics)
                .Build();
        }
    }
}
