using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalculator;

namespace calculator.Operations
{
   abstract class SingleOperation : IOperation
    {
        public double Calculate(params double[] numbers)
        {
            if (numbers == null || numbers.Length != 1)
            {
                throw new InvalidOperationException(message: "Requares one operand.");
            }
            return OnCalculate(numbers[0]);
        }

        abstract protected double OnCalculate(double num);
    }
}
