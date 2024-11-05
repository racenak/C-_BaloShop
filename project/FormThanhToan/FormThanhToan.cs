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
        private DataTable selectedProductsTable;

        private void LoadData()
        {
            List<Product> products = thanhtoanbll.GetAllProducts();
            DataTable dataTable = thanhtoanbll.ConvertToDataTable(products);
            dataGridView2.DataSource = dataTable;
        }
        private void LoadComboBoxData()
        {
            // Giả sử bạn đã có phương thức lấy danh sách màu sắc, giá và hãng từ cơ sở dữ liệu.
            List<string> colors = thanhtoanbll.GetAllColors(); // Lấy danh sách màu sắc
            List<string> brands = thanhtoanbll.GetAllBrands(); // Lấy danh sách hãng
            List<string> priceRanges = new List<string> { "Dưới 100", "100-500", "Trên 500" }; // Các khoảng giá

            comboBox1.DataSource = colors;
            comboBox3.DataSource = brands;
            comboBox2.DataSource = priceRanges;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeSelectedProductsTable(); // Khởi tạo bảng sản phẩm đã chọn
            LoadComboBoxData();
        }

        private void InitializeSelectedProductsTable()
        {
            selectedProductsTable = new DataTable();
            selectedProductsTable.Columns.Add("ProductID", typeof(int));
            selectedProductsTable.Columns.Add("Name", typeof(string));
            selectedProductsTable.Columns.Add("ProductNumber", typeof(string));
            selectedProductsTable.Columns.Add("Color", typeof(string));
            selectedProductsTable.Columns.Add("Size", typeof(string));
            selectedProductsTable.Columns.Add("Weight", typeof(decimal));
            selectedProductsTable.Columns.Add("StandardCost", typeof(decimal));
            selectedProductsTable.Columns.Add("ListPrice", typeof(decimal));
            selectedProductsTable.Columns.Add("SafetyStockLevel", typeof(int));
            selectedProductsTable.Columns.Add("ProductSubCategory", typeof(string));

            dataGridView1.DataSource = selectedProductsTable; // Gán bảng cho DataGridView1
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu dòng được chọn hợp lệ
            {
                // Lấy dòng sản phẩm được chọn từ DataGridView2
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Lấy từng thuộc tính của sản phẩm từ dòng được chọn và thêm vào bảng
                DataRow newRow = selectedProductsTable.NewRow();
                newRow["ProductID"] = selectedRow.Cells["ProductID"].Value ?? DBNull.Value;
                newRow["Name"] = selectedRow.Cells["Name"].Value ?? DBNull.Value;
                newRow["ProductNumber"] = selectedRow.Cells["ProductNumber"].Value ?? DBNull.Value;
                newRow["Color"] = selectedRow.Cells["Color"].Value ?? DBNull.Value;
                newRow["Size"] = selectedRow.Cells["Size"].Value ?? DBNull.Value;
                newRow["Weight"] = selectedRow.Cells["Weight"].Value ?? DBNull.Value;
                newRow["StandardCost"] = selectedRow.Cells["StandardCost"].Value ?? DBNull.Value;
                newRow["ListPrice"] = selectedRow.Cells["ListPrice"].Value ?? DBNull.Value;
                newRow["SafetyStockLevel"] = selectedRow.Cells["SafetyStockLevel"].Value ?? DBNull.Value;
                newRow["ProductSubCategory"] = selectedRow.Cells["ProductSubCategory"].Value ?? DBNull.Value;

                // Thêm sản phẩm vào bảng
                selectedProductsTable.Rows.Add(newRow);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) {
                string productName = textBox1.Text.Trim();

                // Gọi phương thức tìm kiếm theo tên sản phẩm từ BLL
                List<Product> searchResults = thanhtoanbll.SearchProductsByName(productName);

                // Hiển thị kết quả lên DataGridView
                dataGridView2.DataSource = searchResults;
            }
            else
            {
                string brand = comboBox3.SelectedItem?.ToString();
                string color = comboBox1.SelectedItem?.ToString();

                // Thiết lập minPrice và maxPrice từ lựa chọn trong ComboBox
                decimal? minPrice = null;
                decimal? maxPrice = null;

                switch (comboBox2.SelectedItem?.ToString())
                {
                    case "Dưới 100,000":
                        maxPrice = 100000;
                        break;
                    case "100,000 - 200,000":
                        minPrice = 100000;
                        maxPrice = 200000;
                        break;
                    case "200,000 - 500,000":
                        minPrice = 200000;
                        maxPrice = 500000;
                        break;
                    case "Trên 500,000":
                        minPrice = 500000;
                        break;
                }

                // Gọi phương thức SearchProducts từ BLL
                List<Product> searchResults = thanhtoanbll.SearchProducts(brand, color, minPrice, maxPrice);

                // Hiển thị kết quả lên DataGridView
                dataGridView2.DataSource = searchResults;

                // Gọi phương thức SearchProducts từ BLL

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
            InitializeSelectedProductsTable(); // Khởi tạo bảng sản phẩm đã chọn
            LoadComboBoxData();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
