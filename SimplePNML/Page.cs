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

        [XmlElement("page")]
        public List<Page> Pages { get; private set; } = new List<Page>();

        [XmlElement("place")]
        public List<Place> Places { get; private set; } = new List<Place>();

        [XmlElement("transition")]
        public List<Transition> Transitions { get; private set; } = new List<Transition>();

        [XmlElement("arc")]
        public List<Arc> Arcs { get; private set; } = new List<Arc>();

    }
}
