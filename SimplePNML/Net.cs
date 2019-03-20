using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("net")]
    public class Net : IIdentifiable
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("page")]
        public List<Page> Pages { get; set; } = new List<Page>();

        public static Net Create(string id = null, string type = null)
        {
            id = id ?? Guid.NewGuid().ToString();
            return new Net()
            {
                Id = id,
                Type = type
            };
        }

        public Net WithPages(params Page[] pages)
        {
            Pages.AddRange(pages);
            return this;
        }

    }
}
