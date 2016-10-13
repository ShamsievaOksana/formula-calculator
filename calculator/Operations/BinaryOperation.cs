using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator.Operations
{
    abstract class BinaryOperation : IOperation
    {
        public double Calculate(params double[] numbers)
        {

            if (numbers == null || numbers.Length != 2)
            {
                throw new InvalidOperationException(message: "Requares two operands.");
            }

            return OnCalculate(numbers[0], numbers[1]);
        }


        protected abstract double OnCalculate(double num1, double num2);

    }
}
