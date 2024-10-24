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
    public partial class Formquanlinhanvien : Form
    {
        public Formquanlinhanvien()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void InitializeDataGridView()
        { //ghi làm ví dụ 
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Orderdate", "Họ Tên");
            dataGridView1.Columns.Add("SalePerson", "ROLE");
            dataGridView1.Columns.Add("Price", "Giới tính");



            dataGridView1.Columns["ID"].Width = 100;
            dataGridView1.Columns["Orderdate"].Width = 120;
            dataGridView1.Columns["SalePerson"].Width = 100;
            dataGridView1.Columns["Price"].Width = 100;



            dataGridView1.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView1   .Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
            dataGridView1.Rows.Add("ID03", "01/01/2000", "VU", 200000);
            dataGridView1.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView1.Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
            dataGridView1.Rows.Add("ID03", "01/01/2000", "VU", 200000);
            dataGridView1.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView1.Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
            dataGridView1.Rows.Add("ID03", "01/01/2000", "VU", 200000);
            dataGridView1.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView1.Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
            dataGridView1.Rows.Add("ID03", "01/01/2000", "VU", 200000);
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
