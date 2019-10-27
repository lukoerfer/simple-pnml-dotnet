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
    public class Page : IIdentifiable
    {
        /// <summary>
        /// Gets or sets the identifier of this page
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
        public NodeGraphics Graphics { get; set; }

        /// <summary>
        /// Gets a collection containing the sub-pages of this page
        /// </summary>
        [XmlElement("page")]
        public List<Page> Pages { get; set; } = new List<Page>();

        /// <summary>
        /// Gets a collection containing the places of this page
        /// </summary>
        [XmlElement("place")]
        public List<Place> Places { get; set; } = new List<Place>();

        /// <summary>
        /// Gets a collection containing the transitions of this page
        /// </summary>
        [XmlElement("transition")]
        public List<Transition> Transitions { get; set; } = new List<Transition>();

        /// <summary>
        /// Gets a collection containing the arcs of this page
        /// </summary>
        [XmlElement("arc")]
        public List<Arc> Arcs { get; set; } = new List<Arc>();


        /// <summary>
        /// Creates a new PNML page
        /// </summary>
        /// <param name="id">An identifier, should be unique, defaults to a random GUID</param>
        /// <param name="name">A label, can be null</param>
        /// <returns>A new PNML page</returns>
        public static Page Create(string id = null, Label name = null)
        {
            id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            return new Page()
            {
                Id = id,
                Name = name
            };
        }
        
        /// <summary>
        /// Adds sub-pages to this page
        /// </summary>
        /// <param name="pages">Any number of pages</param>
        /// <returns>A reference to this page</returns>
        public Page WithPages(params Page[] pages)
        {
            Pages.AddRange(pages);
            return this;
        }

        /// <summary>
        /// Adds places to this page
        /// </summary>
        /// <param name="places">Any number of places</param>
        /// <returns>A reference to this page</returns>
        public Page WithPlaces(params Place[] places)
        {
            Places.AddRange(places);
            return this;
        }

        /// <summary>
        /// Adds transitions to this page
        /// </summary>
        /// <param name="transitions">Any number of transitions</param>
        /// <returns>A reference to this page</returns>
        public Page WithTransitions(params Transition[] transitions)
        {
            Transitions.AddRange(transitions);
            return this;
        }

        /// <summary>
        /// Adds arcs to this page
        /// </summary>
        /// <param name="arcs">Any number of arcs</param>
        /// <returns>A reference to this page</returns>
        public Page WithArcs(params Arc[] arcs)
        {
            Arcs.AddRange(arcs);
            return this;
        }

    }
}
