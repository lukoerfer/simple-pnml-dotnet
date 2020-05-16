using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
    [Equals]
    [XmlType("place")]
    public class Place : Connectable, ICollectable, INamed, INode, IToolExtendable
    {
        /// <summary>
        /// Gets or sets a label containing the name of the place
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets how to visualize this place
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphics { get; set; }

        /// <summary>
        /// Gets or sets a label defining the initial marking of the place
        /// </summary>
        /// <remarks>This label should contain a positive integer</remarks>
        [XmlElement("initialMarking")]
        public Label InitialMarking { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ToolSpecific> ToolSpecificData { get; set; } = new List<ToolSpecific>();

        /// <summary>
        /// Creates a new place
        /// </summary>
        public Place() : base() { }

        /// <summary>
        /// Creates a new place
        /// </summary>
        /// <param name="id"></param>
        public Place(string id) : base(id) { }

        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Name)
                .Include(Graphics)
                .Include(InitialMarking)
                .Include(ToolSpecificData)
                .Collect();
        }
    }
}
