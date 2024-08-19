using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.UserInterface
{
    public class UserInput
    {
        private int validInput;
        private int numberOfUserOptions;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numberOfOptions"></param>
        public UserInput(int numberOfOptions) 
        { 
            this.numberOfUserOptions = numberOfOptions;
        }


        public DateTime? GetDateInput()
        {
            Console.WriteLine("Please insert the date of the habit: {Format dd-MM-yyyy}.");

            string dateInput = Console.ReadLine();
            DateTime? date = ValidateDateInput(dateInput);
            return date;
        }

        public string GetNameInput()
        {
            Console.WriteLine("Please enter the name of the habit");

            string habitName = Console.ReadLine();
            if (string.IsNullOrEmpty(habitName))
            {
                Console.WriteLine("User Input is empty");
            }
            return habitName;
        }

        public int GetHoursInput()
        {
            Console.WriteLine("Please insert the number hours of the habit.");

            string hoursInput = Console.ReadLine();
            if (string.IsNullOrEmpty(hoursInput))
            {
                Console.WriteLine("Input is empty");
            }
            try
            {
                return int.Parse(hoursInput);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        
        /// <summary>
        /// Get user input
        /// </summary>
        /// <returns>Integer between 0 - 4 (current length of enum)</returns>
        public int GetValidatedUserInput()
        {

            string input = Console.ReadLine();
            bool isValid = false;

            while (isValid == false)
            {
                isValid = ValidateInput(input);
            }

            return validInput;
        }

        /// <summary>
        /// Validate input. Must be an integer
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        private bool ValidateInput(string userInput)
        {
            if (userInput == null)
            {
                Console.WriteLine($"Input value {userInput} is Invalid");
                return false;
            }
            int parsedInteger;
            bool validInteger = int.TryParse(userInput, out parsedInteger);
            if (parsedInteger < 0 || parsedInteger > numberOfUserOptions)
            {
                Console.WriteLine($"Input value {userInput} is Invalid");
                return false;
            }
            validInput = parsedInteger;
            
            return true;


        }

        private DateTime? ValidateDateInput(string dateInput)
        {
            if (string.IsNullOrWhiteSpace(dateInput))
            {
                Console.WriteLine("date is empty");
            }
            try
            {
                DateTime date = DateTime.ParseExact(dateInput, "dd-MM-yyyy", CultureInfo.CurrentCulture);
                return date;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse '{0}'", dateInput);
                return null;
            }
        }
    }
}
