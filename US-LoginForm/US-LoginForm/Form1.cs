using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace US_LoginForm
{
    public partial class Form1 : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = LAPTOP-R2F6MLBI; Initial Catalog = formdatabaseDB ; Integrated Security= TRUE;");
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string passaword = txtpass.Text;

            if (txtusername.Text !="" && txtpass.Text !="")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Users ",con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (username == dr["username"].ToString() && passaword == dr["passaword"].ToString())
                    {
                        MessageBox.Show("welcome " + username);
                    }
                    else
                    {
                        MessageBox.Show("Username or Passaword is not correct");
                    }
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("please fill in the blank");
            }
        }
    }
}
