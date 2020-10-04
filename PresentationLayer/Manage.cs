using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer.Models;

namespace PresentationLayer
{
    public partial class Manage : Form
    {
        private User user;

        private UserBusiness userBusiness;
        private CategoryBusiness categoryBusiness;
        private ProductBusiness productBusiness;
        public Manage(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(user);
            Hide();
            main.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //4315
            int code = 0;
            bool check = false;
            do
            {
                code = new Random().Next(100000, 999999);
                check = false;
                foreach (User user in userBusiness.GetUsers())
                {
                    if (user.Code == code)
                    {
                        check = true;
                        break;
                    }
                }
            } while (check);
            User newUser = new User
            {
                Code = code,
                Name = textBox4.Text,
                Surname = textBox3.Text,
                BirthDate = dateTimePicker1.Value.Date.ToString("yyyy'/'MM'/'dd"),
                EMail = textBox5.Text
            };
            userBusiness.InsertUser(newUser);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add7
            userBusiness.DeleteUser(Int32.Parse(textBox7.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //2
            int code = 0;
            bool check = false;
            do
            {
                code = new Random().Next(1000, 9999);
                check = false;
                foreach (Category user in categoryBusiness.GetCategories())
                {
                    if (user.Code == code)
                    {
                        check = true;
                        break;
                    }
                }
            } while (check);
            Category category = new Category
            {
                Code = code,
                Name = textBox2.Text
            };
            categoryBusiness.InsertCategory(category);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //6178
            int code = 0;
            bool check = false;
            do
            {
                code = new Random().Next(1000, 9999);
                check = false;
                foreach (Product user in productBusiness.GetProducts())
                {
                    if (user.Code == code)
                    {
                        check = true;
                        break;
                    }
                }
            } while (check);
            foreach (Category category in categoryBusiness.GetCategories())
            {
                if (Int32.Parse(textBox6.Text) == category.Code)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                MessageBox.Show("Category code not valid");
                textBox6.Text = "";
                textBox6.Focus();
            }
            Product product = new Product
            {
                Code = Int32.Parse(textBox6.Text) * 10000 + code,
                Name = textBox1.Text,
                ExpirationDate = dateTimePicker2.Value.Date.ToString("yyyy'/'MM'/'dd"),
                Price = Int32.Parse(textBox8.Text)
            };
            productBusiness.InsertProduct(product);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //add9
            productBusiness.DeleteProduct(Int32.Parse(textBox9.Text));
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy'/'MM'/'dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy'/'MM'/'dd";
        }
    }
}
