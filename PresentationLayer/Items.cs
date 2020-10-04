using BusinessLayer;
using DataLayer.Models;
using System;
using PresentationLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Items : Form
    {
        private User user;
        private ItemBusiness itemBusiness;
        public Items(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Show();
            dateTimePicker1.Hide();
            numericUpDown1.Minimum = 100000;
            numericUpDown1.Maximum = 999999;
            numericUpDown1.Value = 100000;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Hide();
            dateTimePicker1.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Show();
            dateTimePicker1.Hide();
            numericUpDown1.Minimum = 1000;
            numericUpDown1.Maximum = 9999;
            numericUpDown1.Value = 1000;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Show();
            dateTimePicker1.Hide();
            numericUpDown1.Minimum = 10000000;
            numericUpDown1.Maximum = 99999999;
            numericUpDown1.Value = 10000000;
        }

        private void Items_Load(object sender, EventArgs e)
        {
            itemBusiness = new ItemBusiness();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy'/'MM'/'dd";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main main = new Main(user);
            Hide();
            main.ShowDialog();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radioButton1.Checked)
            {
                foreach (Item item in itemBusiness.GetItemsByCode((int)numericUpDown1.Value))
                {
                    listBox1.Items.Add(item.ToString());
                }
            }
            else if (radioButton2.Checked)
            {
                foreach (Item item in itemBusiness.GetItemsByDate(dateTimePicker1.Value.Date.ToString("yyyyMMdd")))
                {
                    listBox1.Items.Add(item.ToString());
                }
            }
            else if (radioButton3.Checked)
            {
                foreach (Item item in itemBusiness.GetItemsByCategory((int)numericUpDown1.Value))
                {
                    listBox1.Items.Add(item.ToString());
                }
            }
            else if (radioButton4.Checked)
            {
                foreach (Item item in itemBusiness.GetItemsByProduct((int)numericUpDown1.Value))
                {
                    listBox1.Items.Add(item.ToString());
                }
            }
            else
            {
                foreach (Item item in itemBusiness.GetItems())
                {
                    listBox1.Items.Add(item.ToString());
                }
             }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
            numericUpDown1.Hide();
            dateTimePicker1.Hide();
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage manage = new Manage(user);
            Hide();
            manage.ShowDialog();
            Close();
        }
    }
}
