using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace sqlDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";
            string sql = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];
                DataRow newRow = dt.NewRow();
                newRow["Name"] = "Bubble";
                newRow["Age"] = 33;
                dt.Rows.Add(newRow);

                dt.Rows[0]["Name"] = "Tron";

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                /*Console.WriteLine(commandBuilder.GetUpdateCommand().CommandText);
                Console.WriteLine(commandBuilder.GetInsertCommand().CommandText);
                Console.WriteLine(commandBuilder.GetDeleteCommand().CommandText);*/
                adapter.Update(ds);
                ds.Clear();
                adapter.Fill(ds);
                foreach(DataColumn column in dt.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}\t");
                    Console.WriteLine();
                }
                foreach(DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                    {
                        Console.WriteLine($"{cell}\t");
                        Console.WriteLine();
                    }
                }
            }
            Console.Read();

        }
    }
}
