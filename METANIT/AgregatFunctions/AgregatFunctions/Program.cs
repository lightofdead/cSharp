using System;
using Microsoft.Data.SqlClient;

namespace AgregatFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlCOUNT = "SELECT COUNT(*) FROM Users";
                SqlCommand command = new SqlCommand(sqlCOUNT, connection);
                object count = command.ExecuteScalar();

                command.CommandText = "SELECT MIN(age) FROM Users";
                object minAge = command.ExecuteScalar();

                command.CommandText = "SELECT MAX(age) FROM Users";
                object maxAge = command.ExecuteScalar();

                Console.WriteLine($"В таблице {count} объектов\n" +
                    $"Минимальный возраст:{minAge}\nМаксимальный возраст: {maxAge}");


            }
            Console.Read();
        }
    }
}
