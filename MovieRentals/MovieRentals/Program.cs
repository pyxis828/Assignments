using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> customers =  new Dictionary<string, string>(); //dictionary of customers and phone numbers         
            customers.Add("ToriBrenneison", "440 -555-1234");          
            customers.Add("KirstinWalsh", "216-555-7788");            
            customers.Add("SeanEafford", "216-555-4567"); 
            Dictionary<string, string> dueDate = new Dictionary<string, string>();  //key movie title; value due date (add customer name somehow?)      
            Dictionary<string, string> movieCustomer = new Dictionary<string, string>();     
            List<string> inMovies = new List<string>();                             //lists of which movies are available or
            List<string> outMovies = new List<string>();                            //checked out
            inMovies.Add("The Princess Bride");                                     //add movies
            inMovies.Add("Batman");
            inMovies.Add("Twelve Angry Men");
            inMovies.Add("Gone with the Wind");
            inMovies.Add("The Fifth Element");            
            string checkedOut = "The Princess Bride,KirstinWalsh";                           //checkout a movie               
            CheckOutMovies(checkedOut, inMovies, outMovies, dueDate, movieCustomer);  //call check-out movie method           
            checkedOut = "Batman,SeanEafford";
            CheckOutMovies(checkedOut, inMovies, outMovies, dueDate,  movieCustomer);                
            checkedOut = "Twelve Angry Men,KirstinWalsh";
            CheckOutMovies(checkedOut, inMovies, outMovies, dueDate, movieCustomer);
            checkedOut = "Batman,ToriBreinneson";
            CheckOutMovies(checkedOut, inMovies, outMovies, dueDate, movieCustomer);
            string checkedIn = "The Princess Bride,KirstinWalsh";                       //check in movie   
            CheckInMovies(checkedIn, inMovies, outMovies, dueDate, movieCustomer);      //call check-in movie method
            checkedIn = "Gone with the Wind,ToriBreinneson";
            CheckInMovies(checkedIn, inMovies, outMovies, dueDate, movieCustomer);
            string lateList = CheckForOverdue(outMovies, dueDate);              //call check for overdue movies method           
            string[] lateMovies = lateList.Split(',');                         //put list of overdue movies in an array
            int[] OverdueDaysList = new int[lateMovies.Length];                //overdue values index numbers in this array's
            string[] lateCustomers = new string[lateMovies.Length];            //index correspond with of overdue dyas    
            OverdueDaysList = CalculateDaysOverdue(dueDate, lateMovies);       //i.e. lateMovies[0] is OverdueDays[0] overdue
            string lateCustomerList = MakeFinalLateCutomerList(lateMovies, lateCustomers, movieCustomer);
            Console.WriteLine("The following customers have late movies:\n" + lateCustomerList);  //names only late list
            Console.ReadLine();
            string[] shortLateCustomers = lateCustomerList.Split(' ');
            string lateAlert = LateMessageBuilder(shortLateCustomers, lateMovies, OverdueDaysList, movieCustomer, customers);
            Console.WriteLine(lateAlert);    //comprehensive late movies alert  
            Console.ReadLine();            
        }                                                                    
        static void CheckOutMovies(string checkedOut, List<string>inMovies, List<string>outMovies, Dictionary<string, string> dueDate, Dictionary<string, string> movieCustomer)
        {
            string [] split = checkedOut.Split(',');
            string title = split[0];
            string renter = split[1];
            if (inMovies.Contains(title))                       //if movie is available for rental
            {                
                inMovies.Remove(title);
                outMovies.Add(title);             
                string due = DateTime.Today.AddDays(7).ToString();      //when movie is due back
                dueDate.Add(title, due);                   //adds title of movie as key and due date as value to dictionary
                movieCustomer.Add(title, renter);          //adds title of movie as key and customer's name as value to dictionary 
                Console.WriteLine("{0} has been checked out to {1}", title, renter);
                Console.ReadLine();              
            }
            else
            {
                Console.WriteLine("{0} has already been checked out", title);
                Console.ReadLine();
            }
        }
        static void CheckInMovies(string checkedIn, List<string> inMovies, List<string> outMovies, Dictionary<string, string> dueDate, Dictionary<string, string> movieCustomer)
        {                                               //method to check movies back in
            string[] split = checkedIn.Split(',');
            string title = split[0];
            string[] lateMovie = new string[1];
            if (outMovies.Contains(title))              //if movie is checked out
            {
                outMovies.Remove(title);
                inMovies.Add(title);
                int overdueCheck = CompareDates(dueDate[title], DateTime.Today.ToString());    //check if overdue 
                if (overdueCheck < 0)           //if it is overdue
                {
                    lateMovie[0] = title;
                    int [] days = CalculateDaysOverdue(dueDate, lateMovie);  //calculate how many days overdue it is
                    int fine = 1;
                    int totalFine = days[0] * fine;  //not really necessary but allow fine to be changed                    
                    Console.WriteLine(title + " is " + days[0] + " day(s) overdue, a fine of $1 per day is added for a total of $" + totalFine);
                    Console.ReadLine();                       //alert regarding fine
                }                         
                dueDate.Remove(title);                                      //complete movie check=in
                movieCustomer.Remove(title);
                Console.WriteLine("{0} had been checked back in.", title);
                Console.ReadLine();
            }
            else
            {                                                               //if not checked out
                Console.WriteLine("{0} was never checked out", title);
                Console.ReadLine();
            }
        }
        static int CompareDates (string dueDate, string today)  //compares the due date with today's date
        {
            int result = dueDate.CompareTo(today);              //returns -1 if the book is overdue
            return result;
        }
        static string  CheckForOverdue(List<string> outMovies, Dictionary<string, string> dueDate)//checks for all overdue movie
        {
            int overDue = 0;           
            StringBuilder lateList = new StringBuilder();            
            foreach (string movie in outMovies)                                      //loop over each checked out movie
            {
               if (dueDate.ContainsKey(movie))                                       //access due date with title of movie
                {                                                                    
                    //Console.WriteLine(dueDate[movie]);                               
                    overDue = CompareDates(dueDate[movie], DateTime.Today.AddDays(9).ToString());  //calls Compare date method          
                    if (overDue < 0)                             //days added to  today's date to test functionality
                    {
                         lateList.Append(movie + ",");           //add name of movie to list of late movies                                            
                    }
                  
                }
            }
            return lateList.ToString();
        }
        static int [] CalculateDaysOverdue(Dictionary<string, string> dueDate, string [] lateMovies)
        {                                   //method to calculate how many days overdue an item is
            int daysOverdue = 0;
            int[] daysOverdueList = new int[lateMovies.Length];
            int i = 0;
            foreach (string movie in lateMovies)
            {
                if (dueDate.ContainsKey(movie))
                {
                    TimeSpan days = new TimeSpan();        //instantiate Timespan to calculate how long the movie is overdue
                    DateTime date = DateTime.Today.AddDays(9);               //must pass in types of DateTime to TimeSpan
                    DateTime dateDue = Convert.ToDateTime(dueDate[movie]);
                    days = date.Subtract(dateDue);                             //today's date minus the due date 
                    daysOverdue = days.Days;                                   //round to days                                                           
                }
                daysOverdueList[i] = daysOverdue;
                i++;
            }
            return daysOverdueList;
        }
        static string MakeFinalLateCutomerList (string [] lateMovies, string[] lateCustomers, Dictionary<string, string> movieCustomer)
        {
            int i = 0;                                  //method to eleminate duplicate names from list of customers who have late
            foreach (string movie in lateMovies)        //movies
            {              
                if (movieCustomer.ContainsKey(movie))       //get the name associated with each rented movie which is overdue
                {
                    lateCustomers[i] = movieCustomer[movie];   //move these names to an array
                    i++;
                }
            }           
            Array.Sort(lateCustomers);                                           //sort the array
            StringBuilder finalLateCustomerList = new StringBuilder();
            Stack<string> names = new Stack<string>();
            names.Push(lateCustomers[0]);                          //put the first name from the array into the stack
            foreach (string name in lateCustomers)
            {
                if(name != names.Peek())                           //if the next name is not the same, add it to the stack
                {
                    names.Push(name);
                }
            }
            while(names.Count > 0)
            {
                finalLateCustomerList.Append(names.Pop() + " ");   //pop the names from the stack and append to final list
            }
            return finalLateCustomerList.ToString();
        }
        static string LateMessageBuilder (string[] shortLateCustomers, string[] lateMovies, int[] OverdueDaysList, Dictionary<string, string> movieCustomer, Dictionary<string, string> customers)
        {                                                   //more detailed output regarding late movies
            StringBuilder lateAlert = new StringBuilder();
            lateAlert.Append("The following customers have the overdue movies: \n");           
            foreach(string name in shortLateCustomers)            //for each customer with late movies
            {
                string phone = "";
                if (customers.ContainsKey(name))
                {
                    phone = customers[name];                      //get their phone number
                }
                for(int n = 0; n < lateMovies.Length; n ++)       //for each late movie
                {       //if the name of the late movie corresponds with the name of the person who rented it
                     if (movieCustomer.ContainsKey(lateMovies[n]) && name.Equals(movieCustomer[lateMovies[n]]))
                     {
                         lateAlert.Append(name + " rented " + lateMovies[n] + " which is " + OverdueDaysList[n] + " day(s) overdue. " + name + " can be reached at " + phone + "\n");
                     }           
                }               
            }
            return lateAlert.ToString();
        }
    }   
}
