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
    public partial class Formnhapxuathang : Form
    {
        public Formnhapxuathang()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Formnhapxuathang_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label7.Text = ("ĐANG XUẤT HÀNG :");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Text = ("ĐANG NHẬP HÀNG :");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
