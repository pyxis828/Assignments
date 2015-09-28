using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnySentenceRandom
{
    class Program
    {
        static void Main(string[] args)     //Make a program that will create random sentences 
        {                                   // You will have values for noun, verb and prepositional phrase.          
            bool play = true;
            while(play == true)
            {
                Random randnum = new Random();          //random number generator
                int noun = randnum.Next(1, 11);         //set number variable for noun   
                int verb = randnum.Next(1, 11);         //set number variable for verb
                int phrase = randnum.Next(1, 11);       //set number variable for prepositional phrase
                string [] nounList = { "She", "He", "It", "The cat", "The mongoose",    //create array with list of 10 nouns
                    "The orange", "The trampoline", "Musicians", "Programmers", "The shake" };
                string[] verbList = { "ate", "barbecued", "chirped", "collided", "sang",    //create array with list of 10 verbs
                    "spoke", "cartwheeled", "dined", "watched", "directed" };
                string[] phraseList = {"with the monkeys", "on the porch", "under the moon", "after the storm", "before the prince", "over the lake",
                "in the gazebo", "between the lines", "during the festival", "with them all"};   //create array with list of 10 phrases 
                StringBuilder sentence = new StringBuilder();       //create new stringbuilder to make the sentence
                sentence.Append(nounList[noun - 1] + " ");          //add chosen noun # to sentence  (subtract 1 for index)
                sentence.Append(verbList[verb - 1] + " ");          //add chosen verb # to sentence
                sentence.Append(phraseList[phrase - 1]);            //add chosen phrase # to sentence
                Console.WriteLine(sentence);                        //print out the sentence
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
    }
}
