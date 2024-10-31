using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformForProject
{
    public partial class Form1 : Form
    {
        private string origintext;
        private string user;

        public Form1(string username)
        {
            InitializeComponent();
            user = username;
            origintext = label1.Text;

        }
        private Form currentFormChild;
        
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Location = new Point(118, 84);
            panelbody.Controls.Add(childForm);
            panelbody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }


        private void labeltop_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            label1.Text = origintext;
            label1.Location = new Point(145, 17);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formthanhtoan());
            label1.Text = button2.Text;
            label1.Location = new Point(240, 17);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formbaocao());
            label1.Text = button3.Text;
            label1.Location = new Point(260, 17);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            label1.Text = origintext;
            label1.Location = new Point(145, 17);
        }

        private void labelcolor_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DangNhap.dnForm dnForm = new DangNhap.dnForm();
            this.Hide();
            dnForm.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            username.Text = user;
        }

        private void username_Click(object sender, EventArgs e)
        {

        }
    }
}
