using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace _11_09_2021
{
    public class DataProvider
    {
        private DataProvider _Instance;
        public DataProvider Instance {
            get {
                if(_Instance == null) {
                    string str_cnn = "...";
                    _Instance = new DataProvider(str_cnn);
                }
                return _Instance;
            }
            private set {

            }

        }
        private MySqlConnection connection;
        private DataProvider(string cnn_str) {
            connection = new MySqlConnection(cnn_str);
        }
        public void ExcuteDB(String query) {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }     
        public DataTable GetRecords(string query) {
            DataTable data = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
            connection.Open();
            da.Fill(data);
            connection.Close();
            return data; 
        }
    }
}