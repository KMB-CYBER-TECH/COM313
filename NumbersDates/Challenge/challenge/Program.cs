// Application Programming .NET Programming with C# by Kemfon Moses Bassey
// See https://aka.ms/new-console-template for more information

using System;

        while (true)ex
        {
            Console.Write("Enter a date (YYYY-MM-DD HH-MM) or type 'exit' to quit: ");
            string userInput = Console.ReadLine();

            // Check if the user wants to exit the program
            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }

            // Attempt to parse the input into a DateTime
            if (DateTime.TryParse(userInput, out DateTime userDate))
            {
                CalculateDaysDifference(userDate);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date in the format YYYY-MM-DD HH-MM.");
            }
        }
    }

    // Method to calculate the difference between the entered date and the current date
    static void CalculateDaysDifference(DateTime userDate)
    {
        DateTime currentDate = DateTime.Now;  // Using the full date and time for comparison
        TimeSpan difference = userDate - currentDate;

        // Determine if the entered date is in the past, future, or today
        if (difference.TotalDays > 0)
        {
            Console.WriteLine($"{difference.Days} days and {difference.Hours} hours remain until {userDate.ToString("yyyy-MM-dd HH:mm")}.");
        }
        else if (difference.TotalDays < 0)
        {
            Console.WriteLine($"{Math.Abs(difference.Days)} days and {Math.Abs(difference.Hours)} hours have passed since {userDate.ToString("yyyy-MM-dd HH:mm")}.");
        }
        else
        {
            Console.WriteLine("The entered date is today!");
        }
    