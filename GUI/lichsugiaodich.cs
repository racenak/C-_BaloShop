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
    public partial class lichsugiaodich : Form
    {
        public lichsugiaodich()
        {
            InitializeComponent();
            InitializeDataGridView();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lichsugiaodich_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void InitializeDataGridView()
        { //ghi làm ví dụ 
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("ID", "ID");
            dataGridView2.Columns.Add("Orderdate", "Orderdate");
            dataGridView2.Columns.Add("SalePerson", "SalePerson");
            dataGridView2.Columns.Add("Price", "Price");



            dataGridView2.Columns["ID"].Width = 200;
            dataGridView2.Columns["Orderdate"].Width = 400;
            dataGridView2.Columns["SalePerson"].Width = 200;
            dataGridView2.Columns["Price"].Width = 200;



            dataGridView2.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView2.Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
            dataGridView2.Rows.Add("ID03", "01/01/2000", "VU", 200000);
            dataGridView2.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView2.Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
            dataGridView2.Rows.Add("ID03", "01/01/2000", "VU", 200000);
            dataGridView2.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView2.Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
            dataGridView2.Rows.Add("ID03", "01/01/2000", "VU", 200000);
            dataGridView2.Rows.Add("ID01", "01/01/2000", "DAI", 100000);
            dataGridView2.Rows.Add("ID02", "01/01/2000", "LUAT", 150000);
            dataGridView2.Rows.Add("ID03", "01/01/2000", "VU", 200000);
        }
        String column1Data;
        String column2Data;
        String column3Data;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                // Lấy dữ liệu từ dòng mà người dùng đã click
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Lấy giá trị của từng cột trong dòng
                column1Data = selectedRow.Cells["ID"].Value.ToString();
                column2Data = selectedRow.Cells["Orderdate"].Value.ToString();
                column3Data = selectedRow.Cells["SalePerson"].Value.ToString();

                // ... lấy thêm các cột khác nếu cần

                // Tạo và hiển thị form chi tiết
                var PopupForm = new FormchitietDH(column1Data,column2Data,column3Data);
                // truyền dữ liệu vào form chi tiết
                
                PopupForm.Show();
            }
        }

    

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
