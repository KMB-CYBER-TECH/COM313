//Application Programming .NET Programming with C# by Kemfon Moses Bassey
//See https:aka.ms/new-console-template for more information
using System;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter a date (YYYY-MM-DD) or type 'exit' to quit: ");
            string userInput = Console.ReadLine();
 
            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }
 
            if (DateTime.TryParse(userInput, out DateTime userDate))
            {
                CalculateDaysDifference(userDate);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date in the format YYYY-MM-DD.");
            }
        }
    }
    static void CalculateDaysDifference(DateTime userDate)
    {
        DateTime currentDate = DateTime.Now.Date;
        TimeSpan difference = userDate - currentDate;
 
        if (difference.Days > 0)
        {
            Console.WriteLine($"{difference.Days} days remain until {userDate.ToString("yyyy-MM-dd")}.");
        }
        else if (difference.Days < 0)
        {
            Console.WriteLine($"{Math.Abs(difference.Days)} days have passed since {userDate.ToString("yyyy-MM-dd")}.");
        }
        else
        {
            Console.WriteLine("The entered date is today!");
        }
    }
}






