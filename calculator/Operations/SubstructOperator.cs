﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator.Operations
{
    class SubstructOperator : BinaryOperation
    {
        protected override double OnCalculate(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
