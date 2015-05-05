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
    public partial class Users : Form
    {

        public string ID { get; set; }
        public string PW { get; set; }

        public string Type { get; set; }

        public int Salary { get; set; }

        public Users()
        {
            InitializeComponent();
            username_txt.DataBindings.Add("Text", this, "ID");
            password_txt.DataBindings.Add("Text", this, "PW");
            type_txt.DataBindings.Add("Text", this, "Type");
            salary_txt.DataBindings.Add("Text", this, "Salary");
   
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search s = new Search("User");
            s.MdiParent = this.MdiParent;
            s.Show();
        }

        private void AddUser(object sender, EventArgs e)
        {
            if(password_txt.Text!=confirm_txt.Text)
            {
                MessageBox.Show("Error Passwords don't match !!");
                password_txt.Text = "";
                confirm_txt.Text = "";
                return;
            }
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Create_User";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@PW", PW);
            SQLConnection.cmd.Parameters.AddWithValue("@Type", Type);
            SQLConnection.cmd.Parameters.AddWithValue("@Salary", Salary);
            SQLConnection.cmd.ExecuteNonQuery();
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            MessageBox.Show("User Created successfully !");
        }

        private void DeleteUser(object sender, EventArgs e)
        {
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Delete_User";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@PW", PW);
            SQLConnection.cmd.ExecuteNonQuery();
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            MessageBox.Show("User Deleted successfully !");
        }

        private void ChangePW(object sender, EventArgs e)
        {
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Change_PW";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@Old_PW", PW);
            string NewPW = confirm_txt.Text;
            SQLConnection.cmd.Parameters.AddWithValue("@New_PW",NewPW);
            SQLConnection.cmd.ExecuteNonQuery();
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            MessageBox.Show("Password changed successfully !");
        }
        private void ChangeSalary(object sender, EventArgs e)
        {
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Change_Salary";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@Salary", Salary);
            SQLConnection.cmd.ExecuteNonQuery();
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            MessageBox.Show("Salary successfully !");
        }

     

       

     

       
    }
}
