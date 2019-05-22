using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML net
    /// </summary>
    [XmlType("net")]
    public class Net : IIdentifiable
    {
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
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns>A new PNML net</returns>
        public static Net Create(string id = null, string type = null)
        {
            id = id ?? Guid.NewGuid().ToString();
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
