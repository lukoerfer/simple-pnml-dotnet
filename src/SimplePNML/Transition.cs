using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML transition
    /// </summary>
    [XmlType("transition")]
    public class Transition : IConnectable
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
        /// Creates a new PNML transition
        /// </summary>
        /// <param name="id"></param>
        /// <param name="graphics"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Transition Create(string id = null, Graphics graphics = null, Label name = null)
        {
            id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            return new Transition()
            {
                Id = id,
                Graphics = graphics,
                Name = name
            };
        }
    }
}
