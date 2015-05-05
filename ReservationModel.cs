﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ERS
{
    class ReservationModel
    {
        public DataSet FillBox()
        {
            DataSet ds = new DataSet();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Retrieve_Rooms";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.adapter.SelectCommand = SQLConnection.cmd;
            SQLConnection.adapter.Fill(ds);
            SQLConnection.cmd.Parameters.Clear();
            return ds;
        }

        public int AddReservationModel(int Customer_ID,int Room_ID,string Start_Time,string End_Time,string status)
        {
            int suc = 0;
            int suc2=0;
            var dateAndTime = DateTime.Now;
            string Date = dateAndTime.ToString("MM-dd-yyyy");
            Date = Date + " " + Start_Time;
            DateTime StartDate = new DateTime();
            try
            {
                StartDate = DateTime.ParseExact(Date, "MM-dd-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
               
                return -1;
            }

            if(DateTime.Compare(DateTime.Now, StartDate)<0)
            {
                SQLConnection.cmd.Parameters.Clear();
                return -6;
            }

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.Parameters.AddWithValue("@C_ID", Customer_ID);
            SQLConnection.cmd.Parameters.AddWithValue("@R_ID", Room_ID);
            SQLConnection.cmd.Parameters.AddWithValue("@Start_Time", StartDate);



            if (End_Time != "")
            {
                if (status == "Room is Full")
                {
                    string temp = DateTime.Now.ToString("MM-dd-yyyy");
                    string end = temp + " " + End_Time;
                    DateTime enddate = new DateTime();
                    try
                    {
                        enddate = DateTime.ParseExact(end, "MM-dd-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception X)
                    {

                        SQLConnection.cmd.Parameters.Clear();
                        return -2;
                    }
                    int compareCurrent = DateTime.Compare(DateTime.Now, enddate);
                    int CompareDif = DateTime.Compare(enddate, StartDate);
                    if (compareCurrent < 1)
                    {
                        SQLConnection.cmd.Parameters.Clear();
                        return -8;
                    }
                    else if (CompareDif < 1 || CompareDif == 0)
                    {
                        SQLConnection.cmd.Parameters.Clear();
                        return -4;
                    }

                    SQLConnection.cmd.Parameters.Clear();
                    SQLConnection.cmd.CommandType = CommandType.Text;
                    SQLConnection.cmd.CommandText = "SELECT Res_ID from Reservation where R_ID=" + Room_ID.ToString() + "AND ENDTIME is NULL";
                    SQLConnection.conn.Open();
                    int Res_ID = (int)SQLConnection.cmd.ExecuteScalar();
                    SQLConnection.conn.Close();
                    SQLConnection.cmd.Parameters.Clear();
                    SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
                    SQLConnection.cmd.Parameters.AddWithValue("@Res_ID", Res_ID);
                    SQLConnection.cmd.Parameters.AddWithValue("@StartTime", StartDate);
                    SQLConnection.cmd.Parameters.AddWithValue("@EndTime", enddate);
                    SQLConnection.cmd.CommandText = "Edit_Reservation";
                    SQLConnection.conn.Open();
                    SQLConnection.cmd.ExecuteNonQuery();
                    SQLConnection.conn.Close();
                    return 2;

                }
                else
                {
                    string temp = DateTime.Now.ToString("MM-dd-yyyy");
                    string end = temp + " " + End_Time;
                    DateTime enddate = new DateTime();
                    try
                    {
                        enddate = DateTime.ParseExact(end, "MM-dd-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception X)
                    {

                        SQLConnection.cmd.Parameters.Clear();
                        return -2;
                    }
                    int compareCurrent = DateTime.Compare(DateTime.Now, enddate);
                    int CompareDif = DateTime.Compare(enddate, StartDate);
                    if (compareCurrent < 1)
                    {
                        suc2 = -3;
                        SQLConnection.cmd.Parameters.AddWithValue("@End_Time", DBNull.Value);
                    }
                    else if (CompareDif < 1 || CompareDif == 0)
                    {
                        SQLConnection.cmd.Parameters.Clear();
                        return -4;
                    }
                    else
                        SQLConnection.cmd.Parameters.AddWithValue("@End_Time", enddate);
                }
            }
            else
            {
                SQLConnection.cmd.CommandType = CommandType.Text;
                SQLConnection.cmd.CommandText = "SELECT Res_ID from Reservation where R_ID=" + Room_ID.ToString() + "AND ENDTIME is NULL";
                SQLConnection.conn.Open();
                int Res_ID = (int)SQLConnection.cmd.ExecuteScalar();
                SQLConnection.conn.Close();
                if(Res_ID > 0)
                {
                    SQLConnection.cmd.Parameters.Clear();
                    return -9;
                }
                SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
                SQLConnection.cmd.Parameters.AddWithValue("@End_Time", DBNull.Value);
            }
            SQLConnection.cmd.CommandText = "New_Reservation";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.conn.Open();
            try
            {

            suc  =  SQLConnection.cmd.ExecuteNonQuery();
            }
            catch (Exception X)
            {
                SQLConnection.conn.Close();
                SQLConnection.cmd.Parameters.Clear();
                return -5;
            }
            SQLConnection.conn.Close();
            SQLConnection.cmd.Parameters.Clear();
            if (suc2 == -3) return suc2;
            return suc;
        }

        public DataSet  ChangeRoomModel(string temp)
        {
            DataSet ds = new DataSet();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "SELECT C_ID , StartTime  FROM Reservation where EndTime is NULL AND R_ID=" + temp + ";";
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.adapter.SelectCommand = SQLConnection.cmd;
            SQLConnection.adapter.Fill(ds);
            SQLConnection.cmd.Parameters.Clear();
            return ds;
        }

        public DataSet GetCustomerDataModel(int ID)
        {
            DataSet ds2 = new DataSet();
            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "SELECT Name , Mobile  FROM Customer where C_ID=" + ID.ToString() + ";";
            SQLConnection.adapter.SelectCommand = SQLConnection.cmd;
            SQLConnection.adapter.Fill(ds2);
            SQLConnection.cmd.Parameters.Clear();
            return ds2;
        }

        public DataSet CustomerSearch(double mobile)
        {
            DataSet ds = new DataSet();
            SQLConnection.cmd.Parameters.Clear();

            SQLConnection.cmd.CommandText = " SELECT C_ID , Name FROM Customer where Mobile=" + mobile.ToString() + ";";
            SQLConnection.cmd.CommandType = CommandType.Text;
             try
            {
                SQLConnection.adapter.SelectCommand = SQLConnection.cmd;
                SQLConnection.adapter.Fill(ds);
                SQLConnection.cmd.Parameters.Clear();
               
                
                
            }
            catch
             {
                 SQLConnection.cmd.Parameters.Clear();
                 SQLConnection.conn.Close();
                 return  null;
            }
             SQLConnection.cmd.Parameters.Clear();
             SQLConnection.conn.Close();
            return ds;
        }
    }
}
