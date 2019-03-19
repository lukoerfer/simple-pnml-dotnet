using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlRoot("pnml")]
    public class PNML
    {
        [XmlElement("net")]
        public List<Net> Nets { get; set; } = new List<Net>();

        public void Write(Stream target)
        {
            BuildSerializer().Serialize(target, this);
        }

        public void Write(TextWriter target)
        {
            BuildSerializer().Serialize(target, this);
        }

        public void Write(FileInfo target)
        {
            Write(target.OpenWrite());
        }

        public string Write()
        {
            using (TextWriter writer = new StringWriter())
            {
                BuildSerializer().Serialize(writer, this);
                return writer.ToString();
            }
        }

        public static PNML Read(Stream source)
        {
            return (PNML) BuildSerializer().Deserialize(source);
        }

        public static PNML Read(TextReader source)
        {
            return (PNML) BuildSerializer().Deserialize(source);
        }

        public static PNML Read(FileInfo source)
        {
            return Read(source.OpenRead());
        }

        public static PNML Read(string source)
        {
            using (TextReader reader = new StringReader(source))
            {
                return (PNML)BuildSerializer().Deserialize(reader);
            }
        }

        protected static XmlSerializer BuildSerializer()
        {
            return new XmlSerializer(typeof(PNML), "http://www.pnml.org/version-2009/grammar/pnml");
        }

        protected static XmlSerializerNamespaces BuildNamespaces()
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, "http://www.pnml.org/version-2009/grammar/pnml");
            return namespaces;
        }

    }
}
