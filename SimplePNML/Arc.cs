using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("arc")]
    public class Arc : IIdentifiable
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        [XmlAttribute("target")]
        public string Target { get; set; }

        [XmlElement("inscription")]
        public Label Inscription { get; set; }

        public static Arc Create(string id = null, IConnectable source = null, IConnectable target = null, Label inscription = null)
        {
            id = id ?? Guid.NewGuid().ToString();
            return new Arc()
            {
                Id = id,
                Source = source?.Id,
                Target = target?.Id,
                Inscription = inscription
            };
        }

        public void SetSource(IConnectable source)
        {
            Source = source?.Id;
        }

        public void SetTarget(IConnectable target)
        {
            Target = target?.Id;
        }

        public void Connect(IConnectable source, IConnectable target)
        {
            Source = source?.Id;
            Target = target?.Id;
        }

    }
}
