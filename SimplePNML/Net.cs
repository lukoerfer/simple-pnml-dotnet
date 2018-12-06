using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("net")]
    public class Net
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("page")]
        public List<Page> Pages { get; set; } = new List<Page>();

        public Net WithId(string id)
        {
            Id = id;
            return this;
        }

        public Net WithType(string type)
        {
            Type = type;
            return this;
        }

        public Net AddPage(Page page)
        {
            Pages.Add(page);
            return this;
        }

        public Net AddPages(params Page[] pages)
        {
            Pages.AddRange(pages);
            return this;
        }
    }
}
