using System;
using System.Collections.Generic;
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


        public string GetDateInput()
        {
            Console.WriteLine("Please insert the date of the habit: {Format dd-mm-yy}.");

            string dateInput = Console.ReadLine();
            //ValidateInput(dateInput);
            return dateInput;
        }

        public int GetHoursInput()
        {
            Console.WriteLine("Please insert the number hours of the habit.");

            string hoursInput = Console.ReadLine();
            //validateHoours
            return int.Parse(hoursInput);
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
    }
}
