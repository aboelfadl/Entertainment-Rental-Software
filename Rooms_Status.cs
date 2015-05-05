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
    public partial class Rooms_Status : Form
    {
        Rooms_Status_Model Model;

        public Rooms_Status()
        {
            InitializeComponent();
            Model = new Rooms_Status_Model();
            LoadRoomsInfo();
        }

        public void LoadRoomsInfo()
        {
            int box_y_pos = 17;

            int RoomCount = Model.GetNumberOfRooms();

            for (int i = 0; i < RoomCount; i++)
            {
                //GroupBox for each room

                GroupBox box = new GroupBox();
                box.Size = new Size(612, 51);
                box.Location = new Point(33, box_y_pos);
                box.Text = "Room " + Model.GetRoomName(i);

                this.Controls.Add(box);

                //Description Labels for each room

                Label Desc_lbl = new Label();
                Desc_lbl.Location = new Point(12, 25);
                Desc_lbl.Text = "Description:";
                Desc_lbl.Size = new Size(63, 13);
                Desc_lbl.ForeColor = Color.Black;
                box.Controls.Add(Desc_lbl);

                Label Desc_txt = new Label();
                Desc_txt.Location = new Point(78, 25);
                Desc_txt.Text = Model.GetRoomDesc(Model.GetRoomName(i));
                Desc_txt.ForeColor = Color.Black;
                box.Controls.Add(Desc_txt);

                //Start time labels for each room

                Label start_lbl = new Label();
                start_lbl.Location = new Point(350, 25);
                start_lbl.Text = "Start Time:";
                start_lbl.Size = new Size(63, 13);
                start_lbl.ForeColor = Color.Black;
                box.Controls.Add(start_lbl);

                Label start_txt = new Label();
                start_txt.Location = new Point(416, 25);
                start_txt.Text = Model.GetStartTime(i);
                start_txt.ForeColor = Color.Black;
                box.Controls.Add(start_txt);

                box_y_pos += 70;
            }
        }
    }
}