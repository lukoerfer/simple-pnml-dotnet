using AutoFixture;
using AutoFixture.NUnit3;

namespace SimplePNML.Tests
{
    public class XmlAutoDataAttribute : AutoDataAttribute
    {
        public XmlAutoDataAttribute() : base(() => CreateFixture()) { }

        private static Fixture CreateFixture()
        {
            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new XmlSpecimenBuilder());
            return fixture;
        }
    }
}
