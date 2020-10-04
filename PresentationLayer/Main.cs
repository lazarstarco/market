using BusinessLayer;
using DataLayer.Models;
using PresentationLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Main : Form
    {
        private UserBusiness userBusiness;
        private CategoryBusiness categoryBusiness;
        private ProductBusiness productBusiness;
        private ItemBusiness itemBusiness;

        private string selectedString = "";

        private User user;
        public Main(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            userBusiness = new UserBusiness();
            categoryBusiness = new CategoryBusiness();
            productBusiness = new ProductBusiness();
            itemBusiness = new ItemBusiness();

            textBox1.Text = user.Name;
            textBox2.Text = user.Surname;

            fillCategories();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem.ToString().Length != 0)
                {
                    selectedString = listBox1.SelectedItem.ToString();
                }
                string[] parsed = listBox1.SelectedItem.ToString().Split(new string[] { " - " }, StringSplitOptions.None);
                int category = Int32.Parse(parsed[0]);

                if (category < 10000)
                {
                    fillProducts(category);
                    textBox3.Text = category + "";
                    listBox1.SelectedIndex = -1;
                }
                else
                {
                    textBox3.Text = category + "";
                    textBox4.Focus();
                    if (textBox4.Text.Length == 0)
                    {
                        textBox4.BackColor = Color.Coral;
                    }
                    else
                    {
                        fillTextBox(selectedString, textBox4.Text);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text.Length == 4)
                {
                    fillProducts(Int32.Parse(textBox3.Text));
                }
                if (textBox3.Text.Length == 0)
                {
                    fillCategories();
                }
                if (textBox3.Text.Length == 8 && textBox4.Text.Length != 0)
                {
                    fillTextBox(selectedString, textBox4.Text);
                    textBox4.BackColor = Color.Wheat;
                }
            }
            catch (Exception)
            {
            }
        }

        private void fillCategories()
        {
            listBox1.Items.Clear();

            foreach (Category category in categoryBusiness.GetCategories())
            {
                listBox1.Items.Add(category.Code + " - " + category.Name);
            }
        }

        private void fillProducts(int categoryCode)
        {
            listBox1.Items.Clear();

            foreach (Product product in productBusiness.GetProducts())
            {
                if ((product.Code / 10000) == categoryCode)
                {
                    string toWrite = product.Code + " - " + product.Name + ": " + product.Price + ";";
                    if ((DateTime.Parse(product.ExpirationDate) - DateTime.Today).Days <= 10)
                    {
                        toWrite += "    Expiring soon";
                    }
                    listBox1.Items.Add(toWrite);
                }
            }
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            textBox3.Focus();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox4.Text.Length == 0)
                {
                    textBox4.Focus();
                }
                else
                {
                    foreach (string str in listBox1.Items)
                    {
                        if (str.Contains(textBox3.Text))
                        {
                            selectedString = str;
                            fillTextBox(str, textBox4.Text);
                        }
                    }
                }
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox4.Text.Length == 0)
                {
                    textBox4.Focus();
                }
                else
                {
                    foreach (string str in listBox1.Items)
                    {
                        if (str.Contains(textBox3.Text))
                        {
                            selectedString = str;
                            fillTextBox(str, textBox4.Text);
                        }
                    }
                }
            }
        }
        private void fillTextBox(string coded, string amount)
        {
            textBox4.BackColor = Color.Wheat;
            try
            {
                textBox5.Text = Int32.Parse(coded.Substring((coded.IndexOf(": ") + 2), coded.IndexOf(";") - (coded.IndexOf(": ") + 2))) * Double.Parse(amount) + "";
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 8 && textBox4.Text.Length != 0)
            {
                string amount = textBox4.Text;
                string calc = textBox5.Text;
                string userCode = user.Code + "";
                string productCode = selectedString.Substring(0, selectedString.IndexOf(" - "));
                int a = selectedString.IndexOf(" - ") + 3;
                int b = selectedString.IndexOf(": ") + 2;
                int c = selectedString.IndexOf(";");
                listBox2.Items.Add(selectedString.Substring(a, b - a - 2) + ": " + selectedString.Substring(b, c - b) + " x " + amount + " = " + calc + " {" + user.Code + textBox3.Text + "}");
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 8 && textBox4.Text.Length != 0)
            {
                fillTextBox(selectedString, textBox4.Text);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel = -1;
            if (listBox2.SelectedIndex != -1)
            {
                sel = listBox2.SelectedIndex;
            }
            if (sel != -1)
            {
                listBox2.Items.RemoveAt(sel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string str in listBox2.Items)
            {
                string code = DateTime.Now.ToString("yyyyMMddHHmmss");
                int a = str.IndexOf("{") + 1;
                int b = str.IndexOf("}");
                int c = str.IndexOf(" x ") + 3;
                int d = str.IndexOf(" = ");
                try
                {
                    Item item = new Item
                    {
                        Code = code,
                        UserCode = Int32.Parse(str.Substring(a, 6)),
                        ProductCode = Int32.Parse(str.Substring((a + 6), 8)),
                        Quantity = Int32.Parse(str.Substring(c, d - c))
                    };
                    itemBusiness.InsertItem(item);
                }
                catch (Exception)
                {
                }
            }
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Items items = new Items(user);
            Hide();
            items.ShowDialog();
            Close();
        }
    }
}