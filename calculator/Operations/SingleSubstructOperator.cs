using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Operations
{
    class SingleSubstructOperator : SingleOperation
    {
        protected override double OnCalculate(double num)
        {
            return num * (-1);
        }
    }
}
