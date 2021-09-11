using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace _11_09_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstring = @"server=127.0.0.1;user=root;password=Mitcutenhat123;database=example07_09_21";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();

                string query = "SELECT * FROM sinh_vien;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "sinh_vien");
                DataTable dt = ds.Tables["sinh_vien"];

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col] + "\t");
                    }

                    Console.Write("\n");                  
                }           
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
