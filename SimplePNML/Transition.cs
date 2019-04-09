using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a transition of a petri net
    /// </summary>
    [XmlType("transition")]
    public class Transition : IConnectable
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }

        [XmlElement("name")]
        public Label Name { get; set; }

        public static Transition Create(string id = null, Graphics graphics = null, Label name = null)
        {
            id = id ?? Guid.NewGuid().ToString();
            return new Transition()
            {
                Id = id,
                Graphics = graphics,
                Name = name
            };
        }
    }
}
