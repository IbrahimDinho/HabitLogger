using HabitLogger.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.DataBase
{
    public class DatabaseManager
    {
        private readonly IDataBase dataBase;
        private readonly Menu menu;

        public DatabaseManager(IDataBase dataBase, Menu menu)
        {
            this.dataBase = dataBase;
            this.menu = menu;
            Create();
        }


        private void Create()
        {
            dataBase.CreateTable();
        }

        public void Insert(DateTime startDate, int hours, string name)
        {
            dataBase.Insert(startDate, hours, name);
        }

        public void ViewAll()
        {
            List<Habit> habits = dataBase.ViewAll<Habit>();
            menu.ShowAll(habits);
        }

        public void Delete()
        {
            Console.WriteLine("What is the Id of habit you want to delete");
            int id = int.Parse(Console.ReadLine());
            dataBase.Delete(id);
        }

        public void Update(DateTime startDate, int hours, string name)
        {
            Console.WriteLine("What is the Id of habit you want to update");
            int id = int.Parse(Console.ReadLine());
            dataBase.Update(id, startDate,hours, name);
        }
    }
}
