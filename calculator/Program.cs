using calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalculator;

namespace Сalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (;;)
            {
                Console.WriteLine("Enter formula:");
                string formula = Console.ReadLine();
                IMathExecutor calc = new MathFormulaExecutor(formula);

                var result = calc.Calculate();

                Console.WriteLine($"Result: {result}\n");
            }
           

        }
        

    }
}
