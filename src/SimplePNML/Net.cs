using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML net
    /// </summary>
    [XmlType("net")]
    [Equals]
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
        /// Creates a new PNML net
        /// </summary>
        /// <param name="id">An identifier, should be unique, defaults to a random GUID</param>
        /// <param name="type">A resource to the PNML grammar of this net, defaults to the grammar for place-transition nets</param>
        /// <returns>A new PNML net</returns>
        public static Net Create(string id = null, string type = null)
        {
            id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            type = string.IsNullOrWhiteSpace(type) ? PLACE_TRANSITION_NET_TYPE : type;
            return new Net()
            {
                Id = id,
                Type = type
            };
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
