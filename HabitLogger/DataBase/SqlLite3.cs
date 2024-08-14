using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.DataBase
{
    public class SqlLite3 : IDataBase
    {

        private const string CONNECTIONSTRING = @"Data Source=DataBase\test.db";
       

        public void CreateTable()
        {
            try
            {
                using (var connection = new SqliteConnection(CONNECTIONSTRING))
                {
                    connection.Open();
                    var tableCmd = connection.CreateCommand();

                    tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS Habit (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Date TEXT,
                                        Hours INTEGER,
                                        Name TEXT
                                        )";

                    tableCmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch(SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var connection = new SqliteConnection(CONNECTIONSTRING))
                {
                    connection.Open();

                    var tableCmd = connection.CreateCommand();
                    tableCmd.CommandText = $"DELETE FROM Habit WHERE Id= {id})";

                    int rowCount = tableCmd.ExecuteNonQuery();
                    if (rowCount == 0)
                    {
                        Console.WriteLine($"Record with id {id} does not exist");
                    }
                    else
                    {
                        Console.WriteLine($"Record with id {id} was deleted");
                    }

                    connection.Close();
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Insert(DateTime startDate, int hours, string HabitName)
        {
            try
            {
                using (var connection = new SqliteConnection(CONNECTIONSTRING))
                {
                    connection.Open();

                    var tableCmd = connection.CreateCommand();
                    tableCmd.CommandText = $"INSERT INTO Habit(Date,Hours,Name) VALUES ('{startDate}', {hours}, '{HabitName}')";

                    tableCmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(int id, DateTime startDate, int hours, string name)
        {
            try
            {
                using (var connection = new SqliteConnection(CONNECTIONSTRING))
                {
                    connection.Open();

                    var tableCmd = connection.CreateCommand();
                    tableCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM Habit WHERE Id = {id})";
                    int checkQuery = Convert.ToInt32(tableCmd.ExecuteScalar());

                    if (checkQuery == 0)
                    {
                        Console.WriteLine($"Record with ID {id} does not exist");
                        connection.Close();
                        return;

                    }

                    tableCmd.CommandText = $"UPDATE Habit SET date = '{startDate}', Hours = {hours}, Name = '{name}' WHERE Id = {id}";

                    tableCmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<T> ViewAll<T>() where T : Habit, new()
        {
            List<T> tableData = new List<T>();
            try
            {
                using var connection = new SqliteConnection(CONNECTIONSTRING);
                connection.Open();

                var sql = "SELECT * FROM Habit";
                using var command = new SqliteCommand(sql, connection);

                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                            var habit = new T
                            {
                             Id = reader.GetInt32(0),
                             StartDate= DateTime.ParseExact(reader.GetString(1), "dd-mm-yy", CultureInfo.CurrentCulture),
                             Hours = reader.GetInt32(2),
                             Name = reader.GetString(3),
                            };
                        tableData.Add(habit);
                        
                    }
                    return tableData;
                }
                else
                {
                    Console.WriteLine("No habits found.");
                }

            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tableData;
        }
    }
}
