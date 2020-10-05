﻿using Xunit;

namespace DemoLibrary.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4, 3, 7)]
        [InlineData(21, 5.25, 26.25)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        public void Add_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, 4, 2)]
        public void Divide_SimpleValuesShouldCalculate(double x, double y, double expected)
        {

            double actual = Calculator.Divide(x, y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_DivideByZero()
        {
            double expected = 0;

            double actual = Calculator.Divide(15, 0);

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(-15, -1, 15)]
        [InlineData(20, 8, 2.5)]
        [InlineData(double.MaxValue, .5, double.MaxValue)]
        [InlineData(double.MinValue, -1, double.MaxValue)]
        [InlineData(-5, 25, -0.2)]
        public void Divide_DivideByNegativeShouldPass(double number, double divider, double answer)
        {
            double expected = answer;

            double actual = Calculator.Divide(number, divider);

            Assert.Equal(expected, actual);

        }
    }
}
