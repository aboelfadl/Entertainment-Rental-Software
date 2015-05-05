using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERS
{
    public partial class Search : Form
    {
        String Table;
        public object y;

        public Search(String TableName)
        {
            InitializeComponent();
            bindingSource1 = new BindingSource();
           
            Table = TableName;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select * from " + Table;
            SQLConnection.cmd.CommandType = CommandType.Text;
            bindingSource1.DataSource = SQLConnection.cmd.ExecuteReader();
            dataGridView.ForeColor = Color.FromArgb(0, 0, 0, 0);
            dataGridView.DataSource = bindingSource1;
            dataGridView.Show();
            SQLConnection.conn.Close();
            dataGridView.MultiSelect = false;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView.CurrentCell;
            int row = cell.RowIndex;
            //test_lbl.Text = dataGridView.Rows[row].Cells[0].Value.ToString();
            //Application.OpenForms["Customers"].Focus();
            ((Form)y).Focus();
            Label temp = (Label)((Form)y).Controls.Find("Info", true)[0];
            temp.Text = dataGridView.Rows[row].Cells[0].Value.ToString();
            this.Close();
        }
    }
}
