using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SQLMetanit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=tempdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
                Console.WriteLine("Свойства подключения");
                Console.WriteLine($"\tСтрока подключения: {connection.ConnectionString}");
                Console.WriteLine($"\tБаза данных: {connection.Database}");
                Console.WriteLine($"\tСервер: {connection.DataSource}");
                Console.WriteLine($"\tВерсия сервера: {connection.ServerVersion}");
                Console.WriteLine($"\tСостояние: {connection.State}");
                Console.WriteLine($"\tWorkstationId: {connection.WorkstationId}");
            }
            Console.WriteLine("Подключение закрыто");
            Console.WriteLine("Программа завершила работу");
            Console.Read();
        }
    }
}
