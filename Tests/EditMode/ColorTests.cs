using NUnit.Framework;
using UnityEngine;

namespace Slothsoft.UnityExtensions.Tests.EditMode {
    [TestFixture(TestOf = typeof(ColorExtensions))]
    sealed class ColorTests {
        [Test]
        public void TestDeconstructWithoutAlpha() {
            (float red, float green, float blue) = new Color(0f, 0.25f, 0.5f);
            Assert.AreEqual(0f, red);
            Assert.AreEqual(0.25f, green);
            Assert.AreEqual(0.5f, blue);
        }
        [Test]
        public void TestDeconstructWithAlpha() {
            (float red, float green, float blue, float alpha) = new Color(0f, 0.25f, 0.5f, 0.75f);
            Assert.AreEqual(0f, red);
            Assert.AreEqual(0.25f, green);
            Assert.AreEqual(0.5f, blue);
            Assert.AreEqual(0.75f, alpha);
        }
        [Test]
        public void TestWithRed() {
            var color = Color.black;
            Assert.AreEqual(Color.red, color.WithRed(1));
            Assert.AreEqual(Color.black, color);
        }
        [Test]
        public void TestWithGreen() {
            var color = Color.black;
            Assert.AreEqual(Color.green, color.WithGreen(1));
            Assert.AreEqual(Color.black, color);
        }
        [Test]
        public void TestWithBlue() {
            var color = Color.black;
            Assert.AreEqual(Color.blue, color.WithBlue(1));
            Assert.AreEqual(Color.black, color);
        }
        [Test]
        public void TestWithAlpha() {
            var color = Color.black;
            Assert.AreEqual(new Color(0, 0, 0, 0), color.WithAlpha(0));
            Assert.AreEqual(Color.black, color);
        }
    }
}