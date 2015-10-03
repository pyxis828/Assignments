using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EvaluatingPostfixExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "593+42**7+*";              //the expression to be evaluated
            Stack<string> numbers = new Stack<string>();    //declare some variables
            double operandTwo;
            double operandOne;           
            string result = "";
            string convert;
            string final = ""; ;
            bool num;
            int i = 0;
            num = CheckForNumber(expression[i]);            //look for numbers method
            while (i < expression.Length)                   //loop within the string
            {                                                     
                if (num)                                    //if a number
                {
                    convert = (expression[i]).ToString();      //convert to string                                              //convert from char to double                    
                    numbers.Push(convert);                     //before pushing to stack
                    i++;                                       //move to next index
                    num = CheckForNumber(expression[i]);       //check again for number 
                }                
                else                                           //if not a number, it is an operator
                {
                    if (numbers.Count > 1)     //makes sure that the final number hasn't been calculated
                    {                                                  
                        operandTwo = int.Parse(numbers.Pop());           //pop out the last 2 numbers
                        operandOne = int.Parse(numbers.Pop());
                        result = OperandConvert(operandOne, operandTwo, expression[i]);   //do some math (method)
                        numbers.Push(result);                           //push that result to the stack
                    }                      
                    if(i < expression.Length-1)                         //check for end of string
                    {
                        i++;                                            //increase index 
                        num = CheckForNumber(expression[i]);            //and check for number
                    }
                    else
                    {                               //if the end of the string is reached, there should 
                        final = numbers.Pop();      //be one number left in the stack; this is the answer                    
                        break;                      //pop it out and exit loop
                    }
                }
            }
            Console.WriteLine(final);               //print out the answer
        }
        static string OperandConvert(double numOne,double numTwo, char operation)
        {                             //method to do math, input 2 numbers from stack and the operator
            string result;
            if (operation == '+')
            {
                result = (numOne + numTwo).ToString();
                return result;
            }
            else if (operation == '-')
            {
                result = (numOne - numTwo).ToString();
                return result;
            }
            else if (operation == '*')
            {
                result = (numOne * numTwo).ToString(); 
                return result;
            }
            else  
            {
                result = (numOne / numTwo).ToString();
                return result;
            }
        }
        static bool CheckForNumber(char check)      //method to check for a number
        {
            string line = check.ToString();
            bool num = Regex.IsMatch(line, "\\d");
            return num;
        }
    }
}
