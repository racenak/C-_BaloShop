using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using DAL;
using System.Reflection;
namespace FormThanhToan
{
    public partial class FormThanhToan : Form
    {
        public FormThanhToan()
        {
            InitializeComponent();
           
        }
        private ThanhToanBLL thanhtoanbll = new ThanhToanBLL();
        private void LoadData()
        {
            List<Product> products = thanhtoanbll.GetAllProducts();
            DataTable dataTable = thanhtoanbll.ConvertToDataTable(products);
            dataGridView2.DataSource = dataTable;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
