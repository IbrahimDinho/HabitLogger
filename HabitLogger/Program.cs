using HabitLogger.DataBase;
using HabitLogger.UserInterface;
using static HabitLogger.UserInterface.Menu;

namespace HabitLogger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            while (true) {
                menu.ShowMenu();
                UserInput userInput = new UserInput(menu.NumberOfOptions);
                int validatedInput = userInput.GetValidatedUserInput();

                SqlLite3 sqlite = new SqlLite3();
                DatabaseManager databaseManager = new DatabaseManager(sqlite, menu);
                switch (validatedInput)
                {
                    case (int)MenuOptions.Close:
                        Environment.Exit(0);
                        break;

                    case (int)MenuOptions.View:
                        databaseManager.ViewAll();
                        break;

                    case (int)MenuOptions.Insert:
                        DateTime? startDate;
                        int hours;
                        string nameOfHabit;
                        GetAllInputs(userInput, out startDate, out hours, out nameOfHabit);
                        if (hours < 0 || string.IsNullOrEmpty(nameOfHabit) || startDate == null)
                        {
                            goto case (int)MenuOptions.Close;
                        }
                        databaseManager.Insert(startDate.Value, hours, nameOfHabit);
                        break;

                    case (int)MenuOptions.Delete:
                        databaseManager.ViewAll();
                        databaseManager.Delete();
                        break;

                    case (int)MenuOptions.Update:
                        GetAllInputs(userInput, out startDate, out hours, out nameOfHabit);
                        if (hours < 0 || string.IsNullOrEmpty(nameOfHabit) || startDate == null)
                        {
                            goto case (int)MenuOptions.Close;
                        }
                        databaseManager.Update(startDate.Value,hours, nameOfHabit);
                        break;

                }
            }

        }

        private static void GetAllInputs(UserInput userInput, out DateTime? startDate, out int hours, out string nameOfHabit)
        {
            startDate = userInput.GetDateInput();
            hours = userInput.GetHoursInput();
            nameOfHabit = userInput.GetNameInput();
        }
    }
}