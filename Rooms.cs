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
    public partial class Rooms : Form
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public Label Info { get; set; }

        public Rooms()
        {
            InitializeComponent();
            Info = new Label();
            Info.Hide();
            Info.Name = "Info";
            Info.TextChanged += Info_TextChanged;
            this.Controls.Add(Info);

            id_txt.DataBindings.Add("Text", this, "ID");
            description_txt.DataBindings.Add("Text", this, "Description");
          //  price_Txt.DataBindings.Add("Text", this, "Price");
        }
        void AddRoom(object sender, EventArgs e)
        {
            SQLConnection.cmd.Parameters.Clear();
            try
            {
                Price = double.Parse(price_Txt.Text);
            }
            catch(Exception X)
            {
                MessageBox.Show("Price must be a decimal number remove any characters");
                return;
            }
            if(ID<1)
            {
                MessageBox.Show("Error ID of room must be a positive number !");
                return;
            }

            SQLConnection.cmd.CommandText = "Create_Room";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@DISC", Description);
            SQLConnection.cmd.Parameters.AddWithValue("@Price", Price);
            try
            {
                SQLConnection.cmd.ExecuteNonQuery();
            }
           catch(Exception X)
            {
                MessageBox.Show(X.Message.ToString());
                SQLConnection.cmd.Parameters.Clear();
                SQLConnection.conn.Close();
                return;
           }
            
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            MessageBox.Show("Room Created successfully");
            Rooms R = new Rooms();
            R.Show();
            this.Close();
        }


        private void Rooms_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search s = new Search("Room");
            s.y = this;
            s.MdiParent = this.MdiParent;
            this.Hide();
            s.Show();
        }

        void Info_TextChanged(object sender, EventArgs e)
        {
            this.Show();
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select R_ID, Disc, Price from Room where R_ID = " + Info.Text;
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.reader = SQLConnection.cmd.ExecuteReader();
            SQLConnection.reader.Read();
            ID = Int32.Parse(SQLConnection.reader["R_ID"].ToString());
            SQLConnection.conn.Close();
            id_txt.Text = ID.ToString();
        }

        private void EditRoom(object sender, EventArgs e)
        {
            SQLConnection.cmd.Parameters.Clear();
            if (ID < 1)
            {
                MessageBox.Show("Error ID of room must be a positive number !");
                return;
            }
            try
            {
                Price = double.Parse(price_Txt.Text);
            }
            catch (Exception X)
            {
                MessageBox.Show("Price must be a decimal number remove any characters");
                return;
            }   
            SQLConnection.cmd.CommandText = "Edit_Room";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            SQLConnection.cmd.Parameters.AddWithValue("@DISC", Description);
            SQLConnection.cmd.Parameters.AddWithValue("@Price", Price);
            try
            {
                int rows = SQLConnection.cmd.ExecuteNonQuery();
                if(rows <1 )
                {
                    MessageBox.Show("Room ID is not Found, Create Using New Button if needed");
                    SQLConnection.conn.Close();
                    SQLConnection.cmd.Parameters.Clear();
                    return;
                }   
            }
            catch (Exception X)
            {
                MessageBox.Show(X.Message.ToString());
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return;
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            MessageBox.Show("Room Edited successfully");
        }

        private void DeleteRoom(object sender, EventArgs e)
        {
            SQLConnection.cmd.Parameters.Clear();

            if (ID < 1)
            {
                MessageBox.Show("Error ID of room must be a positive number !");
                return;
            }
            SQLConnection.cmd.CommandText = "Delete_Room";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            SQLConnection.cmd.Parameters.AddWithValue("@ID", ID);
            try { 
           int rows =  SQLConnection.cmd.ExecuteNonQuery();
                if(rows < 1)
                {
                    MessageBox.Show("Error Room ID not found.");
                    SQLConnection.conn.Close();
                    SQLConnection.cmd.Parameters.Clear();
                    return;
                }
                
                }
            catch(Exception X)
            {
                MessageBox.Show(X.Message.ToString());
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            MessageBox.Show("Room Deleted successfully");

        }

       
    }
}