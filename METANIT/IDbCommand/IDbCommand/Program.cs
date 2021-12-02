using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace IDbCommand
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";
            //string sqlInsert = "INSERT INTO USERS (Name, Age) VALUES ('Bob', 23)";
            //string sqlUpdate = "UPDATE Users SET Age=20 Where Name='Bob'";
            //string sqlDelete = "DELETE  FROM Users WHERE Name='Bob'"
            int age, number;
            String  name, sqlInsert, sqlUpdate;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Подключение успешно создано");
                Console.WriteLine("Введите имя:");
                name = Console.ReadLine();

                Console.WriteLine("Введите возраст");
                age = Int32.Parse(Console.ReadLine());

                sqlInsert = $"INSERT INTO USERS (Name, Age) VALUES ('{name}', {age})";
                SqlCommand command = new SqlCommand(sqlInsert, connection);
                number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");

                Console.WriteLine("Введите имя изменяемого:");
                name = Console.ReadLine();
                Console.WriteLine("Введите новый возраст для изменяемого");
                age = Int32.Parse(Console.ReadLine());
                sqlUpdate = $"UPDATE Users SET Age={age} WHERE Name='{name}'";
                command.CommandText = sqlUpdate;
                number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Обновлено объектов: {number}");
            }
            Console.Read();
        }
    }
}
