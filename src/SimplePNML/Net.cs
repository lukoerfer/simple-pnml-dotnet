using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML net
    /// </summary>
    [Equals]
    [XmlType("net")]
    public class Net : IIdentifiable
    {
        /// <summary>
        /// Defines the PNML grammar for place-transitions nets
        /// </summary>
        public const string PLACE_TRANSITION_NET_TYPE = "http://www.pnml.org/version-2009/grammar/ptnet";

        /// <summary>
        /// Gets or sets the identifier of this net
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type of this net
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets a collection containing the pages of this net
        /// </summary>
        [XmlElement("page")]
        public List<Page> Pages { get; set; } = new List<Page>();

        /// <summary>
        /// Creates a new net
        /// </summary>
        public Net() : this(null, null) { }

        /// <summary>
        /// Creates a new net
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public Net(string id, string type = null)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            Type = string.IsNullOrWhiteSpace(type) ? PLACE_TRANSITION_NET_TYPE : type;
        }

        /// <summary>
        /// Adds pages to this net
        /// </summary>
        /// <param name="pages">Any number of pages</param>
        /// <returns>A reference to this net</returns>
        public Net WithPages(params Page[] pages)
        {
            Pages.AddRange(pages);
            return this;
        }

    }
}
