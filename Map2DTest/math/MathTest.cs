using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.Xna.Framework;
using System;
using MathHelper = Map2D.math.MathHelper;

namespace Map2DTest
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void MathHelperTest()
        {
            Vector2 a = new Vector2(0, 0);
            Vector2 b = new Vector2(1, 1);

            Assert.AreEqual(Math.Sqrt(2), MathHelper.Distance(a, b), 0.0001d);
            Assert.AreEqual(0.785398, MathHelper.AngleRadians(a, b), 0.0001d);

            Assert.AreEqual(0, MathHelper.RadiansToDegrees(0));
            Assert.AreEqual(90, MathHelper.RadiansToDegrees((float)Math.PI / 2), 0.0001d);
            Assert.AreEqual(180, MathHelper.RadiansToDegrees((float) Math.PI), 0.0001d);
            Assert.AreEqual(360, MathHelper.RadiansToDegrees((float)Math.PI * 2), 0.0001d);

            Assert.AreEqual(0, MathHelper.DegreesToRadians(0));

            Assert.AreEqual(0, MathHelper.MapRange(0f, 0f, 1f, 0f, 2f));
            Assert.AreEqual(2, MathHelper.MapRange(1f, 0f, 1f, 0f, 2f));
            Assert.AreEqual(-2, MathHelper.MapRange(-1f, 0f, 1f, 0f, 2f));
        }
    }
}
