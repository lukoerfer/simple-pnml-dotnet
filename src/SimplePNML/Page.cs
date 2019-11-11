using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML page
    /// </summary>
    [Equals]
    [XmlType("page")]
    public class Page : Identifiable, INodeElement
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
        /// Creates a new page
        /// </summary>
        public Page() : this(null) { }

        /// <summary>
        /// Creates a new page
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="graphic"></param>
        public Page(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Sets the name of the page
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A reference to itself</returns>
        public Page WithName(string name)
        {
            Name = new Label(name);
            return this;
        }

        /// <summary>
        /// Sets the name of the page
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A reference to itself</returns>
        public Page WithName(Label name)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// Adds sub-pages to this page
        /// </summary>
        /// <param name="pages">Any number of pages</param>
        /// <returns>A reference to itself</returns>
        public Page WithPages(params Page[] pages)
        {
            Pages.AddRange(pages);
            return this;
        }

        /// <summary>
        /// Adds places to this page
        /// </summary>
        /// <param name="places">Any number of places</param>
        /// <returns>A reference to itself</returns>
        public Page WithPlaces(params Place[] places)
        {
            Places.AddRange(places);
            return this;
        }

        /// <summary>
        /// Adds transitions to this page
        /// </summary>
        /// <param name="transitions">Any number of transitions</param>
        /// <returns>A reference to itself</returns>
        public Page WithTransitions(params Transition[] transitions)
        {
            Transitions.AddRange(transitions);
            return this;
        }

        /// <summary>
        /// Adds arcs to this page
        /// </summary>
        /// <param name="arcs">Any number of arcs</param>
        /// <returns>A reference to itself</returns>
        public Page WithArcs(params Arc[] arcs)
        {
            Arcs.AddRange(arcs);
            return this;
        }

    }
}
