using FigureSettings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class CircleTests
    {
        void TestCircleArea(double radius, double result)
        {
            var circle = new FigureSettings.Circle(radius);
            Assert.AreEqual(result, circle.GetFigureArea());
        }

        [TestMethod]
        public void OrdinaryRadius()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++) 
            {
                var radius = rnd.NextDouble() * 10;
                TestCircleArea(radius, Math.PI * radius * radius);
            }
        }

        [TestMethod]
        public void CreateWithNotPositiveRadius()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var circle = new FigureSettings.Circle(-33);
            });
        }

        [TestMethod]
        public void NormalCreation()
        {
            new FigureSettings.Circle(33);
        }
    }
}
