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
    public partial class Rooms_Report : Form
    {
        Rooms_Report_Model Model;

        public Rooms_Report()
        {
            InitializeComponent();

            Model = new Rooms_Report_Model();

            SetRooms_ComboBox(Model.LoadRooms());
        }

        public void SetRooms_ComboBox(DataSet d)
        {
            rooms_combo.DataSource = d.Tables[0];
            rooms_combo.ValueMember = "R_ID";
            rooms_combo.DisplayMember = "R_ID";
            rooms_combo.SelectedItem = null;
            rooms_combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (oneroom_radio.Checked)
            {
                if (rooms_combo.Text == "")
                    MessageBox.Show("Please choose a room first");
                else
                {
                    if (!Model.Print_One(rooms_combo.Text, from_date.Text, to_date.Text))
                        MessageBox.Show("Empty Results");
                }
            }
            else if (allrooms_radio.Checked)
            {
                if (!Model.Print_ALL(from_date.Text, to_date.Text))
                    MessageBox.Show("Empty Results");
            }
        }
    }
}
