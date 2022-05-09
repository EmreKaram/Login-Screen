using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0003_LoginScreen
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            //Code for my uniqe logo
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pcbLogo.Width - 3, pcbLogo.Height - 3);
            Region rg = new Region(gp);
            pcbLogo.Region = rg;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //If every information is right, this code will be start and change the form
            if (txtName.Text == "EmreKaram" && txtPassword.Text == "1546" && lbl_Code.Text == txt_Code.Text)
            {
                MessageBox.Show("Login sucessful");
                btnLogin.Enabled = false;
                this.Hide();
                Dashboard form1 = new Dashboard();
                form1.ShowDialog();
            }
            //If in the textbox there is a empty or null code, this code will be start and show a error message
            else if (String.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtPassword.Text) && string.IsNullOrEmpty(txt_Code.Text))
            {
                MessageBox.Show("Please fill in all required information");
            }
            //If in the textbox there is a wrong information, this code will be start and show a error message
            else if (txtName.Text != "EmreKaram" && txtPassword.Text != "1546" && lbl_Code.Text != txt_Code.Text)
            {
                MessageBox.Show("Wrong information");
            }
            //If the user don't click the get a code button, this code will be start and show a "please get a code" message
            else if (lbl_Code.Text == ".....")
            {
                MessageBox.Show("Please get a code");
            }
            else
            {
                int kalanhak = Convert.ToInt32(lbl_RightRemaining.Text);
                kalanhak--;
                lbl_RightRemaining.Text = kalanhak.ToString();
                if (lbl_RightRemaining.Text != "0")
                {
                    //Make a random digit between 100000, 1000000.
                    int karmasık = random.Next(100000, 1000000);
                    lbl_Code.Text = karmasık.ToString();
                }
                else
                {
                    //If our right is over this code will be start and show a error message
                    btnLogin.Enabled = false;
                    MessageBox.Show("No right remaining");
                    this.Hide();
                }

            }
            txt_Code.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //This code for password visibility
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
        Random random; 
        private void btn_GetTheCode_Click(object sender, EventArgs e)
        {
            random = new Random();
            int karmasık = random.Next(100000, 1000000);
            lbl_Code.Text = karmasık.ToString();
            lbl_RightRemaining.Text = "5";
            btn_GetTheCode.Enabled = false; //this part is important because the user can only click the get code button once 
        }

        private void btn_CloseTheApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
