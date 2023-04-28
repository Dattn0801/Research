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
            string cs = "Data Source=DESKTOP-TGFPAE0;Initial Catalog=ThucTap;Integrated Security=True";
            SqlConnection cn  = new SqlConnection(cs);

            //1
            cn.Open();
            string query1 = "select count(Masv) from TBLHuongDan";
            SqlCommand command1 = new SqlCommand(query1, cn);
            SqlDataReader reader1 = command1.ExecuteReader();
            while(reader1.Read())
            {
                int soLuongSv = reader1.GetInt32(0);
                Console.WriteLine("Câu 1: Sinh vien tham gia huong dan: " + soLuongSv);
            }
            cn.Close();



            //2
            cn.Open();
            string query="select * from TBLSinhVien";
            SqlCommand command = new SqlCommand(query, cn);
            SqlDataReader reader2 = command.ExecuteReader();
            Console.WriteLine("Câu 2: List sinh vien");
            while (reader2.Read())
            {
                int id = reader2.GetInt32(0);
                string ten = reader2.GetString(1);
                string makhoa = reader2.GetString(2);
                int? namsinh = null;
                if(!reader2.IsDBNull(3))
                {
                    namsinh = reader2.GetInt32(3);
                }

                string quequan = reader2.GetString(4);
               
                Console.WriteLine("{0} \t {1} \t{2} \t{3} \t {4} ",id,ten,makhoa,namsinh,quequan);
            }
            cn.Close();
         

            //3
            cn.Open();
            string query3 = "insert into TBLSinhVien values (241,'Trần Nam Dương','Bio',1990,'NgheAn')";
            SqlCommand command3 = new SqlCommand(query3, cn);
            SqlDataReader readerr = command3.ExecuteReader();
            cn.Close();
            cn.Open();
            string query4 = "select * from TBLSinhVien";
            SqlCommand command4 = new SqlCommand(query4, cn);
            SqlDataReader reader4 = command4.ExecuteReader();
            Console.WriteLine("Câu 3: Add thêm sinh viên");

            while (reader4.Read())
            {
                int id = reader4.GetInt32(0);
                string ten = reader4.GetString(1);
                string makhoa = reader4.GetString(2);
                int? namsinh = null;
                if (!reader4.IsDBNull(3))
                {
                    namsinh = reader4.GetInt32(3);
                }

                string quequan = reader4.GetString(4);

                Console.WriteLine("{0} \t {1} \t{2} \t{3} \t {4} ", id, ten, makhoa, namsinh, quequan);
            }
            cn.Close();


            //4
            cn.Open();
            string query5 = "update TBLSinhVien set Quequan='HaNam' where Masv=7";
            SqlCommand command5 = new SqlCommand(query5, cn);
            SqlDataReader reader5 = command5.ExecuteReader();
            cn.Close();
            cn.Open();
            Console.WriteLine("Câu 4: Cập nhật quê sv lethivan thành ha nam");
            string query6 = "select * from TBLSinhVien";
            SqlCommand command6 = new SqlCommand(query6, cn);
            SqlDataReader reader6 = command6.ExecuteReader();
            while (reader6.Read())
            {
                int id = reader6.GetInt32(0);
                string ten = reader6.GetString(1);
                string makhoa = reader6.GetString(2);
                int? namsinh = null;
                if (!reader6.IsDBNull(3))
                {
                    namsinh = reader6.GetInt32(3);
                }

                string quequan = reader6.GetString(4);

                Console.WriteLine("{0} \t {1} \t{2} \t{3} \t {4} ", id, ten, makhoa, namsinh, quequan);
            }
            cn.Close();



            //5
            cn.Open();
            string query7_1 = "delete from TBLHuongDan where Madt ='Dt04'";
            SqlCommand command7_1 = new SqlCommand(query7_1, cn);
            SqlDataReader reader7_1 = command7_1.ExecuteReader();
            cn.Close();
            cn.Open();
           
            string query7 = "delete from TBLDeTai where Madt ='Dt04'";
            SqlCommand command7 = new SqlCommand(query7, cn);
            SqlDataReader reader7 = command7.ExecuteReader();
            while (reader7.Read())
            {
                int id = reader7.GetInt32(0);
                string ten = reader7.GetString(1);
                string makhoa = reader7.GetString(2);
                int? namsinh = null;
                if (!reader7.IsDBNull(3))
                {
                    namsinh = reader7.GetInt32(3);
                }

                string quequan = reader7.GetString(4);

                Console.WriteLine("{0} \t {1} \t{2} \t{3} \t {4} ", id, ten, makhoa, namsinh, quequan);
            }
            cn.Close();
            Console.ReadKey();
        }
    }
}
