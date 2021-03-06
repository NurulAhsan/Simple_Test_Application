﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Test_Application
{
    public partial class User_Password_Change : Form
    {
        public User_Password_Change()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_Options ob = new User_Options();
            ob.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            OracleCommand thisCommand = sv.thisConnection.CreateCommand();

            thisCommand.CommandText = "update New_User_SignIn set username = '" + textBox1.Text + "',password= '" + textBox2.Text + "'where password= '" + textBox3.Text + "'";

            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;



            try
            {
                int a = thisCommand.ExecuteNonQuery();
                if (a == 1)
                    MessageBox.Show("Updated Successfully");
                else
                {
                    MessageBox.Show("Not Updated...Insert your old Password Perfectly");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Updated");
            }

            sv.thisConnection.Close();
            this.Close();

            User_Options ob = new User_Options();
            ob.Show();
            this.Hide();
        }
    }
}
