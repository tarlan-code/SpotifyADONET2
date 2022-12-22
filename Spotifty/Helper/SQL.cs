using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Helper
{
    static class SQL
    { 
        static string connectionstring = "Server=MSI; Database=Spotify;Trusted_Connection=True;";
        static SqlConnection _connection = null;

        public static SqlConnection Connection {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(connectionstring);
                }
                return _connection;
            }
        }

        public static int ExecCommand(string command)
        {
            int result = 0;
            using(SqlCommand cmd = new SqlCommand(command, Connection))
            {
                Connection.Open();
                result = cmd.ExecuteNonQuery();
                Connection.Close();

            }
            return result;
        }

        public static DataTable ExecQuery(string query)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter sda = new SqlDataAdapter(query, Connection))
            {
                sda.Fill(dt);
            }
            return dt;
        }

    }
}
