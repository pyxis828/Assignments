using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAndAverageScores
{
    class Program                           //Write a program that reads from the console 10 students’   
                                            //test scores between 0 and 100 (int). Calculate and 
    {                                       //print the sum and the average of the test scores. Use a list.    
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter test scores in whole numbers from 1-100 seperated by spaces");  
            string nums = Console.ReadLine();                //ask user to input scores(no number specified, doesn't matter)
            string [] numbers = nums.Split(' ');             //split the numbers into an array at the spaces
            List <string> values = numbers.ToList<string>();        //convert from an array to a list
            List<int> scores = new List<int>();                     //establish new int list
            int sum = 0;                                            
            foreach (string value in values)                        //loop through string list and convert to int list
            {
                scores.Add(int.Parse(value));
            }
            foreach (int score in scores)                           //loop through list of scores, adding them all togethor
            {
                sum += score;
            }
            int divider = scores.Count;                             //find out how many scores were entered 
            int average = sum / divider;                            //divide sum by this number to get average
            Console.WriteLine("The sum of all test scores is {0} and the average score is {1}.", sum, average);
        }
    }                                                               //print out results    
}
