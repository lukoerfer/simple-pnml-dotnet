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
    public class Page : Identifiable, ICollectable, INamed, INodeElement
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
        public Node Graphics { get; set; }

        /// <summary>
        /// Gets or sets the sub-pages of this page
        /// </summary>
        [NotNull]
        [XmlElement("page")]
        public List<Page> Pages { get; set; } = new List<Page>();

        /// <summary>
        /// Gets or sets the places on this page
        /// </summary>
        [NotNull]
        [XmlElement("place")]
        public List<Place> Places { get; set; } = new List<Place>();

        /// <summary>
        /// Gets or sets the transitions on this page
        /// </summary>
        [NotNull]
        [XmlElement("transition")]
        public List<Transition> Transitions { get; set; } = new List<Transition>();

        /// <summary>
        /// Gets or sets the arcs on this page
        /// </summary>
        [NotNull]
        [XmlElement("arc")]
        public List<Arc> Arcs { get; set; } = new List<Arc>();
        
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
            return Collector.Create(this)
                .Collect(Name)
                .Collect(Graphics)
                .Collect(Pages)
                .Collect(Places)
                .Collect(Transitions)
                .Collect(Arcs)
                .Build();
        }
    }
}
