using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML net
    /// </summary>
    [Equals]
    [XmlType("net")]
    public class Net : Identifiable, ICollectable
    {
        /// <summary>
        /// Defines the PNML grammar for place-transitions nets
        /// </summary>
        public const string PLACE_TRANSITION_NET_TYPE = "http://www.pnml.org/version-2009/grammar/ptnet";

        private string _type;

        /// <summary>
        /// Gets or sets the type of this net
        /// </summary>
        [XmlAttribute("type")]
        public string Type
        {
            get => _type;
            set => _type = value ?? PLACE_TRANSITION_NET_TYPE;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets a collection containing the pages of this net
        /// </summary>
        [NotNull]
        [XmlElement("page")]
        public List<Page> Pages { get; set; } = new List<Page>();

        /// <summary>
        /// Creates a new net
        /// </summary>
        public Net() : this(null) { }

        /// <summary>
        /// Creates a new net
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public Net(string id, string type = null)
        {
            Id = id;
            Type = type;
        }

        /// <summary>
        /// Collects all child elements of this net recursively 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return Collector.Create(this)
                .Collect(Name)
                .Collect(Pages)
                .Build();
        }
    }
}
