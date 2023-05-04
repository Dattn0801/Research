using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT4
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = "Data Source=DESKTOP-TGFPAE0;Initial Catalog=ThucTap;Integrated Security=True";
            // query
            string query1 = "select count(Masv) from TBLHuongDan";
            string query2 = "select * from TBLSinhVien";
            string query3 = "insert into TBLSinhVien values (25,'Trần Nam Dương','Bio',1990,'NgheAn')";
            string query4 = "update TBLSinhVien set Quequan='HaNam' where Masv=7";
            string query5 = "delete from TBLHuongDan where Madt ='Dt04'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ExecuteAndReadResult(query1, connection);
                ExecuteAndReadResult(query2, connection);
                ExecuteAndReadResult(query3, connection);
                ExecuteAndReadResult(query4, connection);
                ExecuteAndReadResult(query5, connection);
                connection.Close();
            }
            Console.ReadKey();

        }
        static void ExecuteAndReadResult(string query, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                        }

                    }
                }
            }
        }
    }
}
