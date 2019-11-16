using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class AnnotationTest
    {
        [Test, AutoData]
        public void CanCreateAnnotation(double x, double y)
        {
            Annotation annotation = new Annotation(x, y);
            Assert.AreEqual(x, annotation.Offset.X);
            Assert.AreEqual(y, annotation.Offset.Y);
        }

        [Test, AutoData]
        public void CanCreateAnnotationFluently(double x, double y)
        {
            Annotation annotation = new Annotation()
                .WithOffset(x, y);
            Assert.AreEqual(x, annotation.Offset.X);
            Assert.AreEqual(y, annotation.Offset.Y);
        }
    }
}
