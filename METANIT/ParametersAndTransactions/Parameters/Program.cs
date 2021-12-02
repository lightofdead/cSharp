using System;
using Microsoft.Data.SqlClient;

namespace Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int age = 36;
                string name = "asdgfghfhdfg/.,gm;;'\f';fgl,f";
                string sqlINSERT = "INSERT INTO Users (Name, Age) VALUES(@name, @age);SET @id=SCOPE_IDENTITY()";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlINSERT, connection);

                SqlParameter nameParam = new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100);
                nameParam.Value = name;
                SqlParameter ageParam = new SqlParameter("@age", age);
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(nameParam);
                command.Parameters.Add(ageParam);
                command.Parameters.Add(idParam);

                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Добавлено обюектов {number}\nId нового объекта: { idParam.Value}");

                command.CommandText = "SELECT * FROM Users";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Вход в цикл");
                        string column1 = reader.GetName(0);
                        string column2 = reader.GetName(1);
                        string column3 = reader.GetName(2);

                        Console.WriteLine($"{column1}\t{column3}\t{column2}");

                        while (reader.Read())
                        {
                            object id = reader["Id"];
                            object name2 = reader["Name"];
                            object age2 = reader["age"];

                            Console.WriteLine($"{id}\t{name2}\t{age2}");
                        }
                    }
                }
            }
            Console.Read();
        }
    }
}
