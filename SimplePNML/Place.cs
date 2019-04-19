using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
    [XmlType("place")]
    public class Place : IConnectable
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("initialMarking")]
        public Label InitialMarking { get; set; }

        /// <summary>
        /// Creates a new PNML place
        /// </summary>
        /// <param name="id"></param>
        /// <param name="graphics"></param>
        /// <param name="name"></param>
        /// <param name="initialMarking"></param>
        /// <returns></returns>
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
