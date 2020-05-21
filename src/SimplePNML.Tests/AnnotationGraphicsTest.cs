using System;
using System.Drawing;
using System.Linq;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class AnnotationGraphicsTest
    {
        [Test]
        void CanCreate()
        {
            AnnotationGraphics graphics = new AnnotationGraphics();
            Assert.IsTrue(graphics.IsDefault());
            Assert.Greater(graphics.Collect().Count(), 1);
        }
    }
}
