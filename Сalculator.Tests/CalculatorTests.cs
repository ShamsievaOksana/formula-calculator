using System;
using calculator.Operations;
using Сalculator.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Сalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Sum_10and20_30returned()
        {
            double x = 10;
            double y = 20;
            double expected = 30;
              
            SumOperator sumOperator = new SumOperator();
            double actual = sumOperator.Calculate(x, y);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Method Requares two operands.")]
        public void Sum_SingleValue_InvalidOperationException()
        {
            double x = 10;
            SumOperator sumOperator = new SumOperator();
            double actual = sumOperator.Calculate(x);
            
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Method Requares two operands.")]
        public void Sum_Null_InvalidOperationException()
        {
            SumOperator sumOperator = new SumOperator();
            double actual = sumOperator.Calculate(null);

        }

        [TestMethod]
        public void Substruct_20and10_10returned()
        {
            double x = 20;
            double y = 10;
            double expected = 10;

            SubstructOperator substructOperator = new SubstructOperator();
            double actual = substructOperator.Calculate(x, y);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Method Requares two operands.")]
        public void Substruct_SingleValue_InvalidOperationException()
        {
            double x = 10;
            SubstructOperator substructOperator = new SubstructOperator();
            double actual = substructOperator.Calculate(x);

        }

        [TestMethod]
        public void Divide_20and10_2returned()
        {
            double x = 20;
            double y = 10;
            double expected = 2;

            DivideOperator divideOperator = new DivideOperator();
            double actual = divideOperator.Calculate(x, y);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Method Requares two operands.")]
        public void Divide_SingleValue_InvalidOperationException()
        {
            double x = 10;
            SumOperator divideOperator = new SumOperator();
            double actual = divideOperator.Calculate(x);

        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException), "Method Requares two operands.")]
        public void Divide_10andZeroValue_DivideByZeroException()
        {
            double x = 10;
            double y = 0;
            DivideOperator divideOperator = new DivideOperator();
            double actual = divideOperator.Calculate(x,y);
            
        }

        [TestMethod]
        public void Multiple_10and20_200returned()
        {
            double x = 10;
            double y = 20;
            double expected = 200;

            MultipleOperator multiplOperator = new MultipleOperator();
            double actual = multiplOperator.Calculate(x, y);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Method Requares two operands.")]
        public void Multiple_SingleValue_InvalidOperationException()
        {
            double x = 10;
            MultipleOperator multiplOperator = new MultipleOperator();
            double actual = multiplOperator.Calculate(x);

        }

      


        [TestMethod]
        public void FormulaResult_StringFormula_DoubleValueReturned()
        {
            string formula = "15 - 2 * ((9-5)*(124*3))";
            double expected = -2961;
            
            MathFormulaExecutor formulaExecutor = new MathFormulaExecutor(formula);
            double actual = formulaExecutor.Calculate();
           Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(FormatException), "Method requares not null operand")]
        public void FormulaResult_Null_Exeption()
        {
            string formula = null;

            MathFormulaExecutor formulaExecutor = new MathFormulaExecutor(formula);
            double actual = formulaExecutor.Calculate();
        }


    }
}
