using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ProceduresAndTransactions
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";
            /*string proc1 = @"CREATE PROCEDURE [dbo].[InsertString]
                                @name nvarchar(100),
                                @age int
                             AS
                                INSERT INTO Users (Name, Age)
                                VALUES (@name, @age)
                                SELECT SCOPE_IDENTITY()
                             GO";
            string proc2 = @"CREATE PROCEDURE [dbo].[GetStrings]
                             AS
                                SELECT * FROM Users 
                             GO";*/
            Console.WriteLine("Введите строку");
            string name = Console.ReadLine();
            Console.WriteLine("Введите число");
            int age = Int32.Parse(Console.ReadLine());
            AddStrings(name, age, connectionString);
            GetStrings(connectionString);
            GetMinMaxAge(name, connectionString);
            Console.Read();
        }

        private static void AddStrings(string name, int age, string connectionString)
        {
            string sqlINSERT = "InsertString";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlINSERT, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                SqlParameter ageParam = new SqlParameter
                {
                    ParameterName = "@age",
                    Value = age
                };
                command.Parameters.Add(nameParam);
                command.Parameters.Add(ageParam);
                var id = command.ExecuteScalar();
                Console.WriteLine($"id {id}");
            }
        }
        private static void GetStrings(string connectionString)
        {
            string sqlSELECT = "GetStrings";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSELECT, connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(2)}\t{reader.GetName(1)}");

                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(2);
                            int age = reader.GetInt32(1);
                            Console.WriteLine($"{id} \t{name} \t{age}");
                        }
                    }
                }
            }
        }
        private static void GetMinMaxAge(string name, string connectionString)
        {
            string sqlMinMax = "sp_GetAgeRange";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlMinMax, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };

                SqlParameter minAgeParam = new SqlParameter
                {
                    ParameterName = "minAge",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                SqlParameter maxAgeParam = new SqlParameter
                {
                    ParameterName = "@maxAge",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(nameParam);
                command.Parameters.Add(minAgeParam);
                command.Parameters.Add(maxAgeParam);

                command.ExecuteNonQuery();
                object minAge = command.Parameters["@minAge"].Value;
                object maxAge = command.Parameters["@maxAge"].Value;
                Console.WriteLine($"{minAge}\t{maxAge}");
            }                        
        }

        private static void DoTransaction(string connectionString) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO Users (Name, Age) VALUES('Tim', 34)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Users (Name, Age) VALUES('Kat', 31)";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Данные добавлены в базу данных");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
            }
        }
    }
}

