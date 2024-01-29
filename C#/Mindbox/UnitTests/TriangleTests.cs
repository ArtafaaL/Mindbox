using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class TriangleTests
    {
        void TestTriangleArea(double a, double b, double c, double result)
        {
            var triangle = new FigureSettings.Triangle(a, b, c);
            Assert.AreEqual(result, triangle.GetFigureArea());
        }
        
        [TestMethod]
        public void OrdinaryTriangleSides()
        {
            TestTriangleArea(10, 10, 10, Math.Sqrt(15 * 5 * 5 * 5));
            TestTriangleArea(3, 4, 5, 6);
            TestTriangleArea(41, 9, 40, 180);
            TestTriangleArea(13, 27, 16, Math.Sqrt(28 * 15 * 1 * 12));
        }

        void IsRigthTriangle(double a, double b, double c, bool result)
        {
            var triangle = new FigureSettings.Triangle(a, b, c);
            Assert.AreEqual(result, triangle.IsRigthTriangle());
        }

        [TestMethod]
        public void RigthTriangles()
        {
            IsRigthTriangle(3, 4, 5, true);
            IsRigthTriangle(10, 10, 10, false);
            IsRigthTriangle(41, 9, 40, true);
            IsRigthTriangle(13, 27, 16, false);
        }

        [TestMethod]
        public void CreateWithNotPositiveSide()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var error = new FigureSettings.Triangle(0, 10, 10);
            });
        }

        [TestMethod]
        public void CreateWithInvalidPositiveSides()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var error = new FigureSettings.Triangle(7, 90, 16);
            });
        }

        [TestMethod]
        public void NormalCreation()
        {
            new FigureSettings.Triangle(3, 4, 5);
        }
    }
}
