using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator.Operations
{
    class DivideOperator : BinaryOperation
    {
        protected override double OnCalculate(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException(message: "Can't divide by zero.");
            }
            return num1 / num2;
        }
    }
}
