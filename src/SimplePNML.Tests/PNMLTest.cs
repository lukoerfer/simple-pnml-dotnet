using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PNMLTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(PNML input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PNML));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            PNML output = (PNML)serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }

    }
}
