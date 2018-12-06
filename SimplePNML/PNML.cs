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

        public static PNML Create()
        {
            return new PNML();
        }

        public PNML AddNet(Net net)
        {
            Nets.Add(net);
            return this;
        }

        public PNML AddNets(IEnumerable<Net> nets)
        {
            Nets.AddRange(nets);
            return this;
        }

        public PNML AddNets(params Net[] nets)
        {
            Nets.AddRange(nets);
            return this;
        }

        public PNML ClearNets()
        {
            Nets.Clear();
            return this;
        }

        public void Write(Stream target)
        {
            buildSerializer().Serialize(target, this);
        }

        public void Write(TextWriter target)
        {
            buildSerializer().Serialize(target, this);
        }

        public void Write(FileInfo target)
        {
            Write(target.OpenWrite());
        }

        public string Write()
        {
            using (TextWriter writer = new StringWriter())
            {
                buildSerializer().Serialize(writer, this);
                return writer.ToString();
            }
        }

        public static PNML Read(Stream source)
        {
            return (PNML) buildSerializer().Deserialize(source);
        }

        public static PNML Read(TextReader source)
        {
            return (PNML) buildSerializer().Deserialize(source);
        }

        public static PNML Read(FileInfo source)
        {
            return Read(source.OpenRead());
        }

        public static PNML Read(string source)
        {
            using (TextReader reader = new StringReader(source))
            {
                return (PNML)buildSerializer().Deserialize(reader);
            }
        }

        protected static XmlSerializer buildSerializer()
        {
            return new XmlSerializer(typeof(PNML), "http://www.pnml.org/version-2009/grammar/pnml");
        }

        protected static XmlSerializerNamespaces buildNamespaces()
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, "http://www.pnml.org/version-2009/grammar/pnml");
            return namespaces;
        }

    }
}
