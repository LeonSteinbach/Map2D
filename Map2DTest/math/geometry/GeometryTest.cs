using Microsoft.VisualStudio.TestTools.UnitTesting;

using Map2D.math.geometry;
using Microsoft.Xna.Framework;
using System;

namespace Map2DTest
{
    [TestClass]
    public class GeometryTest
    {
        [TestMethod]
        public void LineTest()
        {
            Point a1 = new Point(0, 0);
            Point b1 = new Point(1, 1);
            Line l1 = new Line(a1, b1);

            Point a2 = new Point(1, 0);
            Point b2 = new Point(0, 1);
            Line l2 = new Line(a2, b2);

            Point a3 = new Point(1, 0);
            Point b3 = new Point(2, 1);
            Line l3 = new Line(a3, b3);

            Assert.AreEqual(45, MathHelper.ToDegrees(l1.Angle()));
            Assert.AreEqual(Math.Sqrt(2), l1.Length(), 0.0001d);
            Assert.IsTrue(l1.Intersects(l2));
            Assert.IsFalse(l1.Intersects(l3));
            Assert.IsFalse(l2.Intersects(l3));
        }
    }
}
