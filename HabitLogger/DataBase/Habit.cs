namespace HabitLogger.DataBase
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int Hours { get; set; }  
    }
}