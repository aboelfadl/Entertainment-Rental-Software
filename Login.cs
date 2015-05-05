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
    public partial class Login : Form
    {
        public string ID { get; set; }

        public Login()
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            //button1.BackColor = Color.LimeGreen;
            label1.Font = new Font("Arial",label1.Font.Size+2,FontStyle.Bold);
            label2.Font = new Font("Arial", label2.Font.Size + 2, FontStyle.Bold);
            username_txt.DataBindings.Add("Text", this, "ID");
            this.AcceptButton = button1;
            this.CancelButton = button2;
          
           
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 1;
            button1.Font = new Font("Arial", button1.Font.Size + 2, FontStyle.Bold);

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.DimGray;
            button2.FlatAppearance.BorderSize = 1;
            button2.Width = 0;
            button2.Height = 0;

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ID=="Admin" || ID=="User")
            {
                MainScreen main = new MainScreen(ID);
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Account not found");
                return;
            }
        }
    }
}
