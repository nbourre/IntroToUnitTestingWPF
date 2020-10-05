using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary
{
    public static class Calculator
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static double Divide(double x, double y)
        {
            if (x == double.MaxValue && y < 1)
            {
                return double.MaxValue;
            }
            else if (y != 0)
            {
                return x / y;
            }
            else
            {
                // Custom business logic for divide by zero
                return 0;
            }


        }

        public static double Power(double v1, double v2)
        {
            return Math.Pow(v1, v2);
        }
    }

}
