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

        public void Connect(IConnectable source, IConnectable target)
        {
            Source = source.Id;
            Target = target.Id;
        }

    }
}
