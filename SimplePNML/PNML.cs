﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlRoot("pnml", Namespace = "http://www.pnml.org/version-2009/grammar/pnml")]
    public class PNML
    {
        [XmlElement("net")]
        public List<Net> Nets { get; set; }

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
            return new XmlSerializer(typeof(PNML));
        }

    }
}