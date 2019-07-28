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
    public class TransitionTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Transition input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Transition));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Transition output = (Transition) serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }

        [TestCase(null), TestCase(""), TestCase("   "), TestCase("test")]
        public void CreateGivesValidId(string id)
        {
            Transition transition = Transition.Create(id);
            Assert.NotNull(transition.Id);
            Assert.IsNotEmpty(transition.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(transition.Id));
        }
    }
}
