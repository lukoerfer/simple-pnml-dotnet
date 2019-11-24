using System;
using System.Drawing;
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

        [Test]
        public void CanSetFillFluently()
        {
            Fill fill = new Fill();
            Annotation annotation = new Annotation()
                .WithFill(fill);
            Assert.AreEqual(fill, annotation.Fill);
        }

        [Test, AutoData]
        public void CanDefineFillFluently(Color color, Color gradientColor, GradientRotation rotation)
        {
            Annotation annotation = new Annotation()
                .WithFill(color, gradientColor, rotation);
            Assert.AreEqual(color, annotation.Fill.Color);
            Assert.AreEqual(gradientColor, annotation.Fill.GradientColor);
            Assert.AreEqual(rotation, annotation.Fill.GradientRotation);
        }

        [Test, AutoData]
        public void CanDefineImageFillFluently(Uri image)
        {
            Annotation annotation = new Annotation()
                .WithFill(image);
            Assert.AreEqual(image, annotation.Fill.Image);
        }

        [Test, AutoData]
        public void CanSetLineFluently()
        {
            Line line = new Line();
            Annotation annotation = new Annotation()
                .WithLine(line);
            Assert.AreEqual(line, annotation.Line);
        }

        [Test, AutoData]
        public void CanDefineLineFluently(Color color, double width, LineShape shape, LineStyle style)
        {
            Annotation annotation = new Annotation()
                .WithLine(color, width, shape, style);
            Assert.AreEqual(color, annotation.Line.Color);
            Assert.AreEqual(width, annotation.Line.Width);
            Assert.AreEqual(shape, annotation.Line.Shape);
            Assert.AreEqual(style, annotation.Line.Style);
        }

        [Test, AutoData]
        public void CanSetFontFluently(Font font)
        {
            Annotation annotation = new Annotation()
                .WithFont(font);
            Assert.AreEqual(font, annotation.Font);
        }
    }
}
