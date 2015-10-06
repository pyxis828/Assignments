using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ValidParentheses      //Given a string comprising just of the characters(),{},[]
                                //determine if it is well-formed or not. Output = True or False
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "[{{}{}()}]";            
            int length = line.Length;       //check length of line -- if odd, the answer must be false
            bool even = IsEven(length);            //method to check for odd or even
            if (even == false)
            {
                Console.WriteLine(false);       
            }
            bool valid;                                 //declare some variables             
            Stack<char> paren = new Stack<char>();
            char opener;
            char next;
            bool set;
            Match open = Regex.Match(line, "[\\[\\{\\(]");      //check for opening characters
            int i = 0;
            while (i < line.Length)                             //loop through the line
            {
                if (open.Success)                               //if opening character found
                {
                    paren.Push(line[i]);                        //push it to the stack
                    opener = paren.Peek();                      //set this character to a variable
                    if (i < line.Length - 1)                    //if not at end of line
                    {
                        i++;                                    //move to the next character 
                    }
                    next = line[i];                           //assign this character to a variable
                    set = CharComparer(opener, next);         //use method to compare the 2 variables
                    while (set == true)                       //while(if) they are a set (open and close)
                    {
                        paren.Pop();                          //pop the opener off the stack
                        if (i < line.Length - 1)              //if not at the end, move to next index  
                        {
                            i++;
                        }
                        if(paren.Count == 0 && (i == line.Length - 1))  //if at end of line and stack is empty
                        {                                               //expression is valid; break out of loop
                            break;
                        }
                        else if (paren.Count > 0)                //if there is another character in the stack
                        {
                            set = CharComparer(paren.Peek(), line[i]);   //compare it to the current index
                            continue;                                    //if a set, continue in loop
                        }
                        else
                        {
                            set = false;                         //if not a set see below
                        }
                    }
                    if (set == false)                       //if the 2 characters are not a set
                    {
                        bool result = CharIsOpen(line[i]);
                        if (result == true)                 //check to see if the 2nd char is 
                        {                                   //open or close
                            continue;                       //if opening character, start at if(open.Success)
                        }
                        else
                        {                               //else there is an incorrect closing character
                            valid = false;              //expression is not valid   
                            Console.WriteLine(valid);   //print result
                            break;                            
                        }
                    }
                }
                i++;                                    //get out of while loop at end of line
            }
            if (paren.Count == 0)                       //if the end of the line has been reached with
            {                                           //no leftover characters in the stack,the
                valid = true;                           //expression is valid, print the result
                Console.WriteLine(valid);
            }
        }

        static bool IsEven(int num)                     //method to check for odd or even
        {
            bool even;
            if (num % 2 == 0)
            {
                even = true;
            }
            else
            {
                even = false;
            }
            return even;
        }
        static bool CharComparer(char opener, char next)  //method to check for open/close set
        {
            bool set;
            if (opener == '(' && next == ')')
            {
                set = true;
                return set;
            }
            if (opener == '[' && next == ']')
            {
                set = true;
                return set;
            }
            if (opener == '{' && next == '}')
            {
                set = true;
                return set;
            }
            else
            {
                set = false;
                return set;
            }
        }
        static bool CharIsOpen(char current) //method to check for whether char is open or close
        {
            string line = current.ToString();
            bool result;
            Match open = Regex.Match(line, "[\\[\\{\\(]");
            if (open.Success)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
