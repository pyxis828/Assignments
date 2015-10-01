using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace StudentNameList
{
    class Program                        //create an app that uses a list to hold student names. 
                                         //After adding, write out options: Add another student, Clear out all students, 
                                         //List all students, show count of students,
    {                                    // save to a file, or exit.Create methods for these operations.
        static void Main(string[] args)
        {
            bool name;                  //declare variables        
            string response = "";
            List<string> nameList = new List<string>();                      //create list to hold the names
            Console.WriteLine("Please enter the student's name");            //ask user to input name
            nameList.Add(Console.ReadLine());                                //read the response and add to the list
            while (name = true)                                              //loop to run follow-up question
            {               
                Console.WriteLine("To add another student, enter \"add,\" to clear the list, enter \"clear,\"" +
                    " to list all students enter \"list,\" to save the list, enter \"save,\" or to exit, enter \"exit.\"");
                response = Console.ReadLine();                              //read and store response
                response.ToLower();                                         //convert answers to lower case if needed
                if (response == "add")                                      //series of if else statements, calling
                {                                                           //appropriate methods.  Loop continues until
                    nameList.Add(AddName());                                //user specifically exits
                }
                else if (response == "clear")
                {
                    ClearList(nameList);                   
                }
                else if (response == "list")
                {
                    Console.WriteLine(WriteList(nameList));                  
                }
                else if (response == "save")
                {
                    Console.WriteLine(SaveList(nameList));                    
                }
                else if (response == "exit")
                {
                    Console.WriteLine(ExitProgram());                    
                    break;
                }
            }                     
        }
        static string AddName ()                                    //method to add additional names
        {
            Console.WriteLine("Please enter the student's name");   
            string name = (Console.ReadLine()); 
            return name;
        }
        static List<string> ClearList (List<string> nameList)       //method to clear list
        {
             nameList.Clear();
             return nameList;
        }
        static string WriteList (List<string> nameList)             //method to list names
        {
            StringBuilder list = new StringBuilder(); 
            foreach (string name in nameList)
            {
                list.Append(name + " ");                        //loop through list and append results to stringbuilder
            }
            return list.ToString();
        }
        static string SaveList (List<string> nameList)          //method to save list to file
        {
            StreamWriter writer = new StreamWriter("Students.txt");     //establish streamwriter and file to store list in
            using (writer)
            {
                foreach(string name in nameList)                        //loop over list and write each name to file
                {
                    writer.WriteLine(name);
                }
            }
            string saved = "The list was saved";                        //alert user that list was saved
            return saved;
        }
        static string ExitProgram()                                     //method to exit program
        {
           string bye = "Goodbye";
           return bye;
        }              
    }
}
