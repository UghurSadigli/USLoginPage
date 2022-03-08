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
    public partial class RegisterForm : Form
    {
      

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }


        SqlConnection con = new SqlConnection("Data source = LAPTOP-R2F6MLBI; Initial Catalog = formdatabaseDB ; Integrated Security= TRUE;");

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text !="" && txtpass.Text !="" && txtrepass.Text !="" )
            {
                if (txtpass.Text == txtrepass.Text)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Users(username,passaword,repassaword) values('" + txtusername.Text + "','" + txtpass.Text + "','" + txtrepass.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("registred be succesfull!");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Passaword and Repassaword  must be the same!");
                }

            }
            else{
                MessageBox.Show("please fill in the blanks!");
            }
        }
    }
}
