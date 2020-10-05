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
    }
}
