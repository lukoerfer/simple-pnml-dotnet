using System;
using System.Drawing;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class FillTest
    {
        [Test, AutoData]
        public void CanCreateColorFill(Color color, Color gradientColor, GradientRotation rotation)
        {
            Fill fill = new Fill(color, gradientColor, rotation);
            Assert.AreEqual(color, fill.Color);
            Assert.AreEqual(gradientColor, fill.GradientColor);
            Assert.AreEqual(rotation, fill.GradientRotation);
            Assert.IsNull(fill.Image);
        }

        [Test, AutoData]
        public void CanCreateImageFill(Uri image)
        {
            Fill fill = new Fill(image);
            Assert.AreEqual(image, fill.Image);
            Assert.IsNull(fill.Color);
            Assert.IsNull(fill.GradientColor);
            Assert.IsNull(fill.GradientRotation);
        }
    }
}
