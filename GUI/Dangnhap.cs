using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DangNhap.BUS;
using WinformForProject;

namespace DangNhap
{
    public partial class dnForm : Form
    {
        private DangNhapBUS bus = new DangNhapBUS();
        public dnForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //togglePwd.Image = Properties.Resources.show1;
            //togglePwd.FlatStyle = FlatStyle.Flat;
            //togglePwd.Image = ResizeImage(Properties.Resources.show1, 20, 13);
            //togglePwd.Image = ResizeImage(Properties.Resources.hide, 20, 13);
            
            
        }
        private Image ResizeImage(Image img, int width, int height)
        {
            return new Bitmap(img, new Size(width, height));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = tkBox.Text;
            string password = mkBox.Text;

            if (bus.Login(username, password))
            {
                label3.Text = "Đăng nhập thành công";
                label3.ForeColor = Color.Green;
                this.Hide();
                Form1 homepage = new Form1(username);
                homepage.ShowDialog();
                this.Close();
                
            }
            else
            {
                label3.Text = "Đăng nhập thất bại";
                label3.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void signupLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormDK dangky = new FormDK();
            dangky.ShowDialog();
            this.Close();
        }
    }
}
