using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAnimalsDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> animals = new Dictionary<string, int>();
            animals.Add("elephants", 6);
            animals.Add("monkeys", 25);
            animals.Add("giraffes", 4);
            animals.Add("seals", 10);
            animals.Add("penguins", 10);
            animals.Add("peacocks", 4);
            animals.Add("turtles", 6);
            animals.Add("zebras", 8);
            animals.Add("hippos", 3);
            animals.Add("rhinos", 2);
            string[] beasts = new string[animals.Count];    //print out ANIMAL with the highest quantity
            int[] numbers = new int[animals.Count];         //create arrays to hold both keys and values                       
            int indexMost = 0;                              //equal to size of dictionary
            int i = 0;                                     
            foreach (KeyValuePair<string, int> animal in animals)   //loop through dictionary
            {
                numbers[i] = (int)animal.Value;     //unbox values and pass to int array at current index
                beasts[i] = (string)animal.Key;    //unbox keys and pass to string array at current index
                i++;
            }                                                           //compare 1st 2 numbers of array
            int currentHigh = HighNumberComparer(numbers[0], numbers[1]);                                                                       
            if (currentHigh == numbers[0])                       
            {
                indexMost = 0;                               //record which index held the higher number
            }
            else
            {
                indexMost = 1;
            }
            for (int n = 2; n < numbers.Length; n++)     //loop through the rest of the array
            {
                int higher = HighNumberComparer(currentHigh, numbers[n]);  //compare to current high
                if (higher == numbers[n])                   //if current index number is higher
                {
                    indexMost = n;                          //record its index and
                    currentHigh = higher;               
                }                                           //print the animal type from the string
            }                                               //array at the same index where the highest 
            Console.WriteLine(beasts[indexMost]);           //number was found
                                                            //Now remove the animal with the least quantity
            int indexLeast = 0;                             //from the dictionary
            int currentLow = LowNumberComparer(numbers[0], numbers[1]);   //compare 1st 2 numbers of array                                                           
            if (currentLow == numbers[0])                       
            {
                indexLeast = 0;                             //record which index held the lower number
            }
            else
            {
                indexLeast = 1;
            }
            for (int x = 2; x < numbers.Length; x++)     //loop through the rest of the array
            {
                int lower = LowNumberComparer(currentLow, numbers[x]);  //compare to current lowest num
                if (lower == numbers[x])                               //if current index number is lower
                {
                    indexLeast = x;                             //record its index and
                    currentLow = lower;                         //record it as current lowest number
                }                                               
            }
            string key = beasts[indexLeast];                    //get string name of least number animal
            animals.Remove(key);                                //this is the key to entry to remove
            Console.WriteLine(animals.Count);                   //print out new count of dictionary  
            Console.WriteLine("To check if a specific animal is in the list, please enter its name");
            string keyCheck = Console.ReadLine();
            string lowKey = keyCheck.ToLower();
            bool listed = animals.ContainsKey(lowKey); 
            if(listed == true)
            {
                Console.WriteLine("There are {0} in the zoo.", lowKey);
            }
            else
            {
                Console.WriteLine("There is no record of {0} in the zoo.  Would you like to add them; enter \"yes\" or \"no\"?", lowKey);
                string response;
                response = Console.ReadLine();
                string responseLow = response.ToLower();
                if(responseLow == "yes")
                {                 
                    Console.WriteLine("Enter the number of {0}", lowKey);
                    string newNumber = Console.ReadLine();
                    animals.Add(lowKey, int.Parse(newNumber));
                }                
            }
        }

        static int HighNumberComparer(int numberOne, int numberTwo)
        {
            if (numberOne > numberTwo)
            {
                return numberOne;
            }
            if (numberTwo > numberOne)
            {
                return numberTwo;
            }
            else
            {
                return numberOne;
            }
        }
        static int LowNumberComparer(int numberOne, int numberTwo)
        {
            if (numberOne < numberTwo)
            {
                return numberOne;
            }
            if (numberTwo < numberOne)
            {
                return numberTwo;
            }
            else
            {
                return numberOne;
            }
        }
    }   
}
