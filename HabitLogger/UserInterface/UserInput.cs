using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HabitLogger.Menu;

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
