using System;
using Microsoft.Data.SqlClient;
namespace SqlDataReaders
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                string sqlSELECT = "SELECT * FROM Users";
                SqlCommand command = new SqlCommand(sqlSELECT, connection);
                using (SqlDataReader reader = command.ExecuteReader()){
                    if (reader.HasRows)
                    {
                        string columnName1 = reader.GetName(0);
                        string columName2 = reader.GetName(2);
                        string columnName3 = reader.GetName(1);
                        Console.WriteLine($"{columnName1}\t{columName2}\t{columnName3}");

                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            String name = reader.GetString(2);
                            int age = reader.GetInt32(1); ;

                            Console.WriteLine($"{id}\t{name}\t{age}");
                        }
                    }
                }
            }
            Console.Read();
        }
    }
}
