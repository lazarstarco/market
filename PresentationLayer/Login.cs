using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Login : Form
    {
        UserBusiness userBusiness;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            userBusiness = new UserBusiness();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (User user in userBusiness.GetUsers())
                {
                    int code = Int32.Parse(textBoxUserCode.Text);
                    if (user.Code == code)
                    {
                        Main main = new Main(user);
                        Hide();
                        main.ShowDialog();
                        Close();
                    }
                }
                label1.Show();
            }
            catch (Exception)
            {
            }
        }

        private void textBoxUserCode_TextChanged(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Name = "Name1",
                Surname = "Surname1"
            };
            Main main = new Main(user);
            Hide();
            main.ShowDialog();
            Close();
        }

        private void textBoxUserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                button1_Click(new object(), new EventArgs());
            }
        }
    }
}
