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

namespace BaloNe
{
    public partial class ThanhToan : Form
    {
        public ThanhToan()
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
            List<int> brands = thanhtoanbll.GetAllBrands(); // Lấy danh sách hãng
            List<string> priceRanges = new List<string> { "Dưới 100", "100-500", "Trên 500" }; // Các khoảng giá

            colors.Insert(0, "Tất cả");

            priceRanges.Insert(0, "Tất cả");

            // Gán DataSource cho ComboBox
            comboBox1.DataSource = colors;
            comboBox2.DataSource = priceRanges;
            comboBox3.DataSource = brands; ;
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
            selectedProductsTable.Columns.Add("Color", typeof(string));
            selectedProductsTable.Columns.Add("Size", typeof(string));
            selectedProductsTable.Columns.Add("StandardCost", typeof(decimal));
            selectedProductsTable.Columns.Add("ListPrice", typeof(decimal));
            selectedProductsTable.Columns.Add("SafetyStockLevel", typeof(int));
            selectedProductsTable.Columns.Add("ProductSubCategoryID", typeof(string));

            dataGridView1.DataSource = selectedProductsTable; // Gán bảng cho DataGridView1

            label13.Text = "";
            label16.Text = "";
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu dòng được chọn hợp lệ (không phải tiêu đề cột)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng sản phẩm được chọn từ DataGridView2
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Tạo một đối tượng Product mới để lưu thông tin của sản phẩm
                var selectedProduct = new Product
                {
                    ProductID = Convert.ToInt32(selectedRow.Cells["ProductID"].Value),
                    Name = selectedRow.Cells["Name"].Value.ToString(),
                    Color = selectedRow.Cells["Color"].Value?.ToString() ?? string.Empty,
                    Size = selectedRow.Cells["Size"].Value?.ToString() ?? string.Empty,
                    StandardCost = selectedRow.Cells["StandardCost"].Value != DBNull.Value ? Convert.ToDecimal(selectedRow.Cells["StandardCost"].Value) : 0,
                    ListPrice = selectedRow.Cells["ListPrice"].Value != DBNull.Value ? Convert.ToDecimal(selectedRow.Cells["ListPrice"].Value) : 0,
                    SafetyStockLevel = Convert.ToInt32(selectedRow.Cells["SafetyStockLevel"].Value),
                    ProductSubCategoryID = Convert.ToInt32(selectedRow.Cells["ProductSubCategoryID"].Value)
                };

                // Thêm sản phẩm được chọn vào bảng DataTable cho DataGridView1
                DataRow newRow = selectedProductsTable.NewRow();
                newRow["ProductID"] = selectedProduct.ProductID;
                newRow["Name"] = selectedProduct.Name;
                newRow["Color"] = selectedProduct.Color;
                newRow["Size"] = selectedProduct.Size;
                newRow["StandardCost"] = selectedProduct.StandardCost;
                newRow["ListPrice"] = selectedProduct.ListPrice;
                newRow["SafetyStockLevel"] = selectedProduct.SafetyStockLevel;
                newRow["ProductSubCategoryID"] = selectedProduct.ProductSubCategoryID;

                // Thêm dòng vào bảng DataTable
                selectedProductsTable.Rows.Add(newRow);

                // Cập nhật lại DataGridView1 với DataTable mới
                dataGridView1.DataSource = selectedProductsTable;

                // Cập nhật tổng giá vào Label13
                UpdateTotalPrice();
                UpdateTotalProductCount();
            }
        }
        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;

            // Duyệt qua các dòng trong selectedProductsTable và tính tổng ListPrice
            foreach (DataRow row in selectedProductsTable.Rows)
            {
                if (row["ListPrice"] != DBNull.Value)
                {
                    totalPrice += Convert.ToDecimal(row["ListPrice"]);
                }
            }

            // Hiển thị tổng giá trên Label13
            label13.Text = $"{totalPrice:C}";
        }
        private void UpdateTotalProductCount()
        {
            int totalCount = selectedProductsTable.Rows.Count;
            label16.Text = $"{totalCount}";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                string productName = textBox1.Text.Trim();

                // Gọi phương thức tìm kiếm theo tên sản phẩm từ BLL
                List<Product> searchResults = thanhtoanbll.SearchProductsByName(productName);

                // Hiển thị kết quả lên DataGridView
                dataGridView2.DataSource = searchResults;
            }
            else
            {
                string selectedColor = comboBox1.SelectedItem?.ToString() == "Tất cả" ? null : comboBox1.SelectedItem?.ToString();
                string selectedBrand = comboBox3.SelectedItem?.ToString() == "Tất cả" ? null : comboBox3.SelectedItem?.ToString();
                decimal? minPrice = null;
                decimal? maxPrice = null;

                // Xử lý khoảng giá từ ComboBox
                if (comboBox2.SelectedItem?.ToString() != "Tất cả")
                {
                    string selectedPriceRange = comboBox2.SelectedItem.ToString();
                    switch (selectedPriceRange)
                    {
                        case "Dưới 100":
                            maxPrice = 100000;
                            break;
                        case "100-500":
                            minPrice = 100000;
                            maxPrice = 500000;
                            break;
                        case "Trên 500":
                            minPrice = 500000;
                            break;
                    }
                }



                // Gọi phương thức tìm kiếm từ BLL
                var results = thanhtoanbll.SearchProducts(selectedBrand, selectedColor, minPrice, maxPrice);

                // Hiển thị kết quả lên DataGridView
                dataGridView2.DataSource = results;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();

            LoadComboBoxData();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializeSelectedProductsTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Giả sử salePersonID là ID của nhân viên bán hàng hiện tại (bạn có thể lấy từ các trường hợp khác, ví dụ nhập từ giao diện)
            int salePersonID = 1;  // Ví dụ, ID của nhân viên bán hàng

            // Tạo danh sách SaleOrderDetail từ các sản phẩm đã chọn trong selectedProductsTable
            List<SaleOrderDetail> saleOrderDetails = new List<SaleOrderDetail>();

            foreach (DataRow row in selectedProductsTable.Rows)
            {
                var saleOrderDetail = new SaleOrderDetail
                {
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    UnitPrice = Convert.ToDecimal(row["ListPrice"]),
                    Quantity = 1  // Giả sử số lượng là 1, bạn có thể thay đổi nếu có input số lượng
                };
                saleOrderDetails.Add(saleOrderDetail);
            }

            // Gọi hàm ProcessPayment để thực hiện thanh toán
            thanhtoanbll.ProcessPayment(salePersonID, saleOrderDetails);

            // Sau khi thanh toán, có thể làm một số việc như reset lại bảng sản phẩm đã chọn hoặc thông báo thanh toán thành công
            InitializeSelectedProductsTable();  // Reset lại bảng sản phẩm đã chọn
            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGiamGia formGiamGia = new FormGiamGia();
            formGiamGia.Show();
        }
    }
}
