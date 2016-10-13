using System;
using calculator;
using System.Linq;
using System.Text;
using calculator.Operations;
using Сalculator.Operations;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Сalculator
{
   class MathFormulaExecutor: IMathExecutor
    {

        private String _formula;
        //Collection for binary operators with key(operation symbol) and priority value 
        Dictionary<char, PrioritizedOperation> _binaryOprations = new Dictionary<char, PrioritizedOperation>();

        //Collection for single operators with key(operation symbol) and priority value 
        Dictionary<char, PrioritizedOperation> _singleOperations = new Dictionary<char, PrioritizedOperation>();

       public MathFormulaExecutor(string formula)
        {
            if (string.IsNullOrEmpty(formula))
            {
                throw new FormatException(message: "Value can't be null or empty.");
            }
            _formula = formula;
            //adding binary Operator object with key and priority to dictionary
            _binaryOprations.Add('+', new PrioritizedOperation {Operation = new SumOperator(), Priority = 0 });
            _binaryOprations.Add('-', new PrioritizedOperation {Operation = new SubstructOperator(), Priority = 1 });
            _binaryOprations.Add('*', new PrioritizedOperation {Operation = new MultipleOperator(), Priority = 2 });
            _binaryOprations.Add('/', new PrioritizedOperation {Operation = new DivideOperator(), Priority = 3 });

            //adding single Operator objects with key and priority to dictionary
            _singleOperations.Add('-', new PrioritizedOperation {Operation = new SingleSubstructOperator(), Priority = 0 });
        }

        //Method to parse formula string
        private string Parse(string formula)
        {
            string result = formula;

            string pattern = @"\([^\(\)]+\)";

            char[] charsToTrim = { '(', ')' };
            var matches = Regex.Matches(formula, pattern);


            if (matches.Count != 0)
            {

                foreach (Match item in matches)
                {
                    string trimmedValue = item.Value.Trim(charsToTrim);
                    double tempResult = Counting(GetExpression(trimmedValue));
                    result = formula.Replace(item.Value, tempResult.ToString());

                }
                return Parse(result);
            }
            return result;
        }

        //Method to calculate formula
        public double Calculate()
        {
           double result = Counting(GetExpression(Parse(_formula)));
           return result;
        }

        //Method return true if symbol is delimeter
        private bool IsDelimeter(char symbol)
        {
            if ((" ".IndexOf(symbol) != -1))
                return true;
            return false;
        }

        //Метод возвращает true, если проверяемый символ - оператор
        //Method return true if symbol is operator
         private bool IsOperator(char symbol)
        {
            if (("+-/*".IndexOf(symbol) != -1))
                return true;
            return false;
        }


        //Метод возвращает приоритет оператора
        //Method return operator priority
         private byte GetPriority(char symbol)
        {
          return _binaryOprations[symbol].Priority;
        }

         private string GetExpression(string input)
        {
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                //Разделители пропускаем
                //Skip Delimeter
                if (IsDelimeter(input[i]))
                    //Move to next symbol
                    continue; //Переходим к следующему символу

                //Если символ - цифра, то считываем все число
                //if symbol is digit than read all number
                if (Char.IsDigit(input[i])) //Если цифра
                {
                    //Читаем до разделителя или оператора, что бы получить число
                    //reading until delineter or operator to get number
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        //adding every digit to number
                        output += input[i]; //Добавляем каждую цифру числа к нашей строке
                        //move to next symbol
                        i++; //Переходим к следующему символу

                        if (i == input.Length) break; //Если символ - последний, то выходим из цикла
                    }

                    //writer spase after number in string with expression
                    output += " "; //Дописываем после числа пробел в строку с выражением
                    //Return on one symbol back, to symbol befor delimeter
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем
                }

                //Если символ - оператор
                if (IsOperator(input[i])) //Если оператор
                {
                    if (operStack.Count > 0) //Если в стеке есть элементы
                        //if out operator priority greater than operator priority in stack than add this operator to expression
                        if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                            output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением
                    //if stack is empty than add operator to stack
                    operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека


                }
            }

            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            //add operators from stack to expression string
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";
            return output; //Возвращаем выражение в постфиксной записи

        }

         private double Counting(string input)
        {
            //calculation result
            double result = 0; //Результат
            //stack for numbers frim expression
            Stack<double> tempStack = new Stack<double>(); //Временный стек для решения

            for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                //if symbol is digit than read add number and add to stack
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a += input[i]; //Добавляем
                        i++;
                        if (i == input.Length) break;
                    }
                    tempStack.Push(double.Parse(a)); //Записываем в стек
                    i--;
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    //Берем два последних значения из стека
                    //Take two numbers from stack 
                    if (tempStack.Count != 1)
                    {
                        double a = tempStack.Pop();
                        double b = tempStack.Pop();
                        //calculate result
                      result = _binaryOprations[input[i]].Operation.Calculate(b, a);
                     
                    }
                    else {
                        //take first number frin stack
                        double a = tempStack.Pop();
                        //calculate result
                        result = _singleOperations[input[i]].Operation.Calculate(a);
                    }
                    //result push back to stack
                    tempStack.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            //return result from first value in stack
            return tempStack.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }


    }
}
