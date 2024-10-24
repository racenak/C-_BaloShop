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
    public partial class Formbaocao : Form
    {
        public Formbaocao()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        { //ghi làm ví dụ 
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("ProductCode", "Mã sản phẩm");
            dataGridView2.Columns.Add("ProductName", "Tên sản phẩm");
            dataGridView2.Columns.Add("Quantity", "Số lượng");
            dataGridView2.Columns.Add("Price", "Giá");
            dataGridView2.Columns.Add("TotalPrice", "Tổng giá");
            dataGridView2.Columns.Add("Brand", "Hãng");


            dataGridView2.Columns["ProductCode"].Width = 100;
            dataGridView2.Columns["ProductName"].Width = 200;
            dataGridView2.Columns["Quantity"].Width = 100;
            dataGridView2.Columns["Price"].Width = 100;
            dataGridView2.Columns["TotalPrice"].Width = 100;
            dataGridView2.Columns["Brand"].Width = 150;


            dataGridView2.Rows.Add("P001", "Balo A", 5, 100000, 500000,"A");
            dataGridView2.Rows.Add("P002", "Balo B", 3, 150000, 450000,"B");
            dataGridView2.Rows.Add("P003", "Balo C", 2, 200000, 400000,"C");
        }

        private void Formbaocao_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
