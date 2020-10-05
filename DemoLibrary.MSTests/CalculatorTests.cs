using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoLibrary.MSTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Divide_DivideByZero()
        {
            double expected = 0;

            double actual = Calculator.Divide(15, 0);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Power_MustPass()
        {
            // Arrange
            double expected = 32;

            // Act
            double actual = Calculator.Power(2, 5);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(4, 3, 7)]
        [DataRow(21, 5.25, 26.25)]
        [DataRow(double.MaxValue, 5, double.MaxValue)]
        public void Add_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Add(x, y);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
