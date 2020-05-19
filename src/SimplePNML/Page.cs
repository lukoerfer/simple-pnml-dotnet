using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML page
    /// </summary>
    [Equals]
    [XmlType("page")]
    public class Page : Identifiable, ICollectable, INamed, INode, IToolExtendable
    {
        /// <summary>
        /// Gets or sets a label containing the name
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets how to visualize the page
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphics { get; set; }

        /// <summary>
        /// Gets or sets the sub-pages of this page
        /// </summary>
        [XmlElement("page")]
        public List<Page> Pages { get; set; } = new List<Page>();

        /// <summary>
        /// Gets or sets the places on this page
        /// </summary>
        [XmlElement("place")]
        public List<Place> Places { get; set; } = new List<Place>();

        /// <summary>
        /// Gets or sets the transitions on this page
        /// </summary>
        [XmlElement("transition")]
        public List<Transition> Transitions { get; set; } = new List<Transition>();

        /// <summary>
        /// Gets or sets the arcs on this page
        /// </summary>
        [XmlElement("arc")]
        public List<Arc> Arcs { get; set; } = new List<Arc>();

        /// <summary>
        /// 
        /// </summary>
        public List<ToolSpecific> ToolSpecificData { get; set; } = new List<ToolSpecific>();

        /// <summary>
        /// Creates a new page
        /// </summary>
        public Page() { }

        /// <summary>
        /// Creates a new page
        /// </summary>
        /// <param name="id"></param>
        public Page(string id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Name)
                .Include(Graphics)
                .Include(Pages)
                .Include(Places)
                .Include(Transitions)
                .Include(Arcs)
                .Include(ToolSpecificData)
                .Collect();
        }
    }
}
