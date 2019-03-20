using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("place")]
    public class Place : IConnectable
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }

        [XmlElement("name")]
        public Label Name { get; set; }

        [XmlElement("initialMarking")]
        public Label InitialMarking { get; set; }

        public static Place Create(string id = null, Graphics graphics = null, Label name = null, Label initialMarking = null)
        {
            id = id ?? Guid.NewGuid().ToString();
            return new Place()
            {
                Id = id,
                Graphics = graphics,
                Name = name,
                InitialMarking = initialMarking
            };
        }

    }
}
