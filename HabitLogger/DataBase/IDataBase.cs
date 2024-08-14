using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.DataBase
{
    public interface IDataBase
    {
        public void CreateTable();

        public void Insert(DateTime startDate, int hours, string HabitName);

        public void Update(int id, DateTime startDate, int hours, string HabitName);

        public void Delete(int id);

        public List<T> ViewAll<T>() where T : Habit, new();
    }
}
