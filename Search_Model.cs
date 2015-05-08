using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ERS
{
    class Search_Model
    {
        public SqlDataReader GetDataSource(String table_name)
        {
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select * from " + table_name;
            SQLConnection.cmd.CommandType = CommandType.Text;
            SqlDataReader temp = SQLConnection.cmd.ExecuteReader();
            DataTable Table = new DataTable();
           

            SQLConnection.conn.Close();
            return temp;
        }
    }
}
