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
            string username = tkBox.Text;
            string password = mkBox.Text;
            bus.Signup(username, password);
            
        }
    }
}
