using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace BetterRandomFunnySentence
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            while (play == true)
            {
                string line = "";                                       //create variable to store text read from file
                StreamReader reader = new StreamReader("nouns.txt");    //declare StreamReader and file name to be read
                using (reader)
                {                                                       //read line from file(if necessary add while loop
                    line = reader.ReadLine();                           //and additional ReadLine to continue while
                }                                                       //line is not null)
                CryptoRandom randnum = new CryptoRandom();  //random number generator
                int noun = randnum.Next(1, 11);         //set number variable for noun   
                int verb = randnum.Next(1, 11);         //set number variable for verb
                int phrase = randnum.Next(1, 11);       //set number variable for prepositional phrase                                 
                string[] nounList = line.Split(',');    //split text from line along commas and store in array       
                string[] verbList = { "ate", "barbecued", "chirped", "collided", "sang",    //create array with list of 10 verbs
                    "spoke", "cartwheeled", "dined", "watched", "directed" };
                string[] phraseList = {"with the monkeys", "on the porch", "under the moon", "after the storm", "before the prince", "over the lake",
                "in the gazebo", "between the lines", "during the festival", "with them all"};   //create array with list of 10 phrases 
                StringBuilder sentence = new StringBuilder();       //create new stringbuilder to make the sentence
                sentence.Append(nounList[noun - 1] + " ");          //add chosen noun # to sentence  (subtract 1 for index)
                sentence.Append(verbList[verb - 1] + " ");          //add chosen verb # to sentence
                sentence.Append(phraseList[phrase - 1]);            //add chosen phrase # to sentence
                Console.WriteLine(sentence);                         //print out the sentence
                StreamWriter writer = new StreamWriter("FunnySentence.txt");
                using (writer)                                      //establish Streamwriter and name of file to write to
                {
                    writer.WriteLine(sentence);                     //write result to the file
                }
                Console.WriteLine("Would you like to play again? Please enter \"yes\" or \"no\":");
                string answer = Console.ReadLine();                 //ask user if they want to play again
                answer.ToLower();                                   //convert answer to lower case if needed
                if (answer == "yes")
                {
                    continue;                                       //run program again if user says they want to play again
                }
                else
                    break;                                          //exit the program if the user doesn't say yes
            }
        }

        class CryptoRandom : RandomNumberGenerator              //method for random number generator with thanks to
        {                                                       //Ben Klopfer at Imagine Technology Group
            private static RandomNumberGenerator r;
            public CryptoRandom()
            {
                r = RandomNumberGenerator.Create();
            }
            public override void GetBytes(byte[] buffer)
            {
                r.GetBytes(buffer);
            }
            public double NextDouble()
            {
                byte[] b = new byte[4];
                r.GetBytes(b);
                return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
            }
            public int Next(int minValue, int maxValue)
            {
                return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
            }
            public int Next()
            {
                return Next(0, Int32.MaxValue);
            }
            public int Next(int maxValue)
            {
                return Next(0, maxValue);
            }
        }
    }
}        