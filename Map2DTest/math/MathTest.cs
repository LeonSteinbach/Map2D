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
        }
    }
}
