using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.UserInterface
{
    public class Menu
    {
        public int NumberOfOptions { get; } = Enum.GetValues(typeof(MenuOptions)).Length - 1;

        private const string Name = "Main Menu";
        private readonly string Question = "What would you like to do from options below?";
        private readonly string dashedLine = "---------------------------------";

        public enum MenuOptions
        {

            Close = 0,
            View = 1,
            Insert = 2,
            Delete = 3,
            Update = 4
        }

        public void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine( Name + Environment.NewLine);
            
            Console.WriteLine(Question);

            Console.WriteLine($"Type {(int)MenuOptions.Close} to {MenuOptions.Close} application");
            Console.WriteLine($"Type {(int)MenuOptions.View} to {MenuOptions.View} all records");
            Console.WriteLine($"Type {(int)MenuOptions.Insert} to {MenuOptions.Insert} Record");
            Console.WriteLine($"Type {(int)MenuOptions.Delete} to {MenuOptions.Delete} Record");
            Console.WriteLine($"Type {(int)MenuOptions.Update} to {MenuOptions.Update} Record");

            Console.WriteLine(dashedLine);


        }
    }
}
