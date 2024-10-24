using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 


namespace WinformForProject
{
    public partial class Formmagiamgia : Form
    {
        public Formmagiamgia()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void InitializeDataGridView()
        { //ghi làm ví dụ 
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ID", "ID Mã Giảm");
            dataGridView1.Columns.Add("Orderdate", "ĐIỀU KIỆN");
            dataGridView1.Columns.Add("SalePerson", "NOTE");
            dataGridView1.Columns.Add("Price", "SỐ LẦN CÒN");



            dataGridView1.Columns["ID"].Width = 100;
            dataGridView1.Columns["Orderdate"].Width = 120;
            dataGridView1.Columns["SalePerson"].Width = 100;
            dataGridView1.Columns["Price"].Width = 100;



            dataGridView1.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView1.Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
