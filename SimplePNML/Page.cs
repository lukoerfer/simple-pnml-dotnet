using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("page")]
    public class Page : IIdentifiable
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public Label Name { get; set; }

        public static Page Create(string id = null, Label name = null)
        {
            id = id ?? Guid.NewGuid().ToString();
            return new Page()
            {
                Id = id,
                Name = name
            };
        }

        [XmlElement("page")]
        public List<Page> Pages { get; private set; } = new List<Page>();

        public Page WithPages(params Page[] pages)
        {
            Pages.AddRange(pages);
            return this;
        }

        [XmlElement("place")]
        public List<Place> Places { get; private set; } = new List<Place>();

        public Page WithPlaces(params Place[] places)
        {
            Places.AddRange(places);
            return this;
        }

        [XmlElement("transition")]
        public List<Transition> Transitions { get; private set; } = new List<Transition>();

        public Page WithTransitions(params Transition[] transitions)
        {
            Transitions.AddRange(transitions);
            return this;
        }

        [XmlElement("arc")]
        public List<Arc> Arcs { get; private set; } = new List<Arc>();

        public Page WithArcs(params Arc[] arcs)
        {
            Arcs.AddRange(arcs);
            return this;
        }

    }
}
