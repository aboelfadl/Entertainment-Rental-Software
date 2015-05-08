using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ERS
{
    class Search_Model
    {
        public void GetDataSource(Search s, String table_name)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select * from " + table_name;
            SQLConnection.cmd.CommandType = CommandType.Text;
            SqlDataReader temp = SQLConnection.cmd.ExecuteReader();

            ((Search)s).SetBinding(temp);

            SQLConnection.conn.Close();
        }
    }
}
