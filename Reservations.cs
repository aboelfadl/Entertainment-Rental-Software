using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Sql;
//using System.Data.SqlTypes;
using System.Windows.Forms;

namespace ERS
{
    public partial class Reservations : Form
    {
        //public int ID { get; set; }

        //public int Customer_ID { get; set; }

        //public int Room_ID { get; set; }

        //public string Start_Time { get; set; }

        //public string End_Time { get; set; }

        int CustomerID;
         ReservationModel Model;
        
        public Reservations()
        {
            InitializeComponent();
            Model = new ReservationModel();
            SetComboBox(Model.FillBox());
            CustomerID = -1;
        }
        public void SetComboBox(DataSet ds)
        {
            room_combobox.DataSource = ds.Tables[0];
            room_combobox.ValueMember = "R_ID";
            room_combobox.DisplayMember = "R_ID";
            room_combobox.SelectedItem = null;
            room_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            room_combobox.SelectedIndexChanged += new EventHandler(Room_Changed);
        }



        void AddReservation(object sender, EventArgs e)
        {

            int R_ID, C_ID;
            if(CustomerID==-1)
            {
                MessageBox.Show("Please choose a customer first by adding their mobile number and clicking search.");
                return;
            }
            C_ID = CustomerID;
            try
            {
                R_ID = Int32.Parse(room_combobox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid room selection.");
                return;
            }
            
           

            if (start_txt.Text == "")
            {
                MessageBox.Show("Please enter a start time for this reservation");
                return;
            }


            int suc = Model.AddReservationModel(C_ID, R_ID, start_txt.Text, end_txt.Text, room_status.Text);


            if (suc==-1)
            {
                MessageBox.Show("Start Time Format is incorrect , Please check");
                return;
            }
           

            else if(suc==-2)
            {
                MessageBox.Show("Incorrect End time please insert in format of HH:MM ");
                return;
            }
            else if (suc==-3)
            {

                MessageBox.Show("End Time can't be entered before the customer finish , Please set it later");
                MessageBox.Show("This reservation will be saved with empty End Time, please set it when customer finish");
                Reservations R = new Reservations();
                R.Show();
                this.Close();
                return;
            }
            else if (suc==-4)
            {
                 MessageBox.Show("End Time Can't be equal or less than  Start Time");
                 return;
            }
            else if(suc==-5)
            {
                MessageBox.Show("Unknow Error , Please Contact your System Administrator , Check if room is not already used");
                return;
            }
            else if (suc == -6)
            {
                MessageBox.Show("Start Time Can't be  more than  Current Time.");
                return;
            }
            else if( suc ==-8)
            {
                MessageBox.Show("End Time Can't be  less than  Current Time.");
                return;
            }
            else if (suc == -9)
            {
                MessageBox.Show("Reservation is already saved");
                return;
            }
            else if(suc==1)
            {
                MessageBox.Show("Reservation created successfully");
                Reservations R = new Reservations();
                R.Show();
                this.Close();
                return;
            }
            else if(suc==2)
            {
                MessageBox.Show("Reservation Saved successfully");
                Reservations R = new Reservations();
                R.Show();
                this.Close();
                return;
            }

            
        }
        
        
        
        private void Room_Changed(object sender, EventArgs e)
        {
            DataSet ds = Model.ChangeRoomModel(room_combobox.Text);

            if (ds.Tables[0].Rows.Count == 0)
            {
                room_status.Text = "Room is Empty";
                custName_txt.Text = "";
                start_txt.Text = "";
                end_txt.Text = ""; 
                custNum_txt.Text = "";
            }
            else
            {
                room_status.Text = "Room is Full";
          CustomerID =(int) ds.Tables[0].Rows[0][0];
                DateTime Strt = (DateTime)ds.Tables[0].Rows[0][1];
                start_txt.Text = Strt.TimeOfDay.ToString();
                start_txt.Text = start_txt.Text.Remove(start_txt.Text.Length - 3);
                  DataSet ds2=   Model.GetCustomerDataModel(CustomerID);
                custName_txt.Text = (string)ds2.Tables[0].Rows[0][0];
                custNum_txt.Text = ds2.Tables[0].Rows[0][1].ToString(); 
            }
        }

        private void Customer_Search(object sender, EventArgs e)
        {
            double test;
            try
            {

                 test = Double.Parse(custNum_txt.Text);
            }
            catch (Exception X)
            {
                MessageBox.Show("Please enter a valid phone number");
                return;
            }

            DataSet ds = new DataSet();
            ds = Model.CustomerSearch(test);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Customer Not Found.");
                return;
            }
           
            else if(ds==null)
            {
                MessageBox.Show("Unknow Error Please Contact the System Administrator.");
                return;
            }
            else
            {
                CustomerID = (int)ds.Tables[0].Rows[0][0];
                custName_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            }


            
        }


    }
}