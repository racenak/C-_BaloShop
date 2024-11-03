using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformForProject;
using DangKy.BUS;

namespace WinformForProject
{
    public partial class FormDK : Form
    {
        private DangKyBUS bus = new DangKyBUS();
        public FormDK()
        {
            InitializeComponent();
        }

        private void dnLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangNhap.dnForm dangnhap = new DangNhap.dnForm();
            dangnhap.ShowDialog();
            this.Close();
        }

        private void dkButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tkBox.Text) || string.IsNullOrEmpty(mkBox.Text) || string.IsNullOrEmpty(lnBox.Text))
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            string username = tkBox.Text;
            string password = mkBox.Text;
            string lastname = lnBox.Text;
            if (bus.Signup(username, password, lastname))
            {
                MessageBox.Show("Đăng ký thành công");
            }
            else MessageBox.Show("Đăng ký không thành");
        }
    }
}
