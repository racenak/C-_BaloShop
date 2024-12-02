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
    public partial class FormGiamGia : Form
    {
        private GiamGiaBLL GiamGiaBLL = new GiamGiaBLL();
        public FormGiamGia()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormGiamGia_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách mã giảm giá từ Service
                List<GiamGiaDTO> offers = GiamGiaBLL.GetAllSpecialOffers();

                // Đổ dữ liệu vào DataGridView
                dataGridViewGiamGia.DataSource = offers;

                // Tùy chọn hiển thị (có thể ẩn các cột không cần thiết nếu muốn)
                dataGridViewGiamGia.Columns["OfferID"].HeaderText = "Mã Giảm Giá";
                dataGridViewGiamGia.Columns["Description"].HeaderText = "Mô Tả";
                dataGridViewGiamGia.Columns["DiscountPercentage"].HeaderText = "Phần Trăm Giảm";
                dataGridViewGiamGia.Columns["StartDate"].HeaderText = "Ngày Bắt Đầu";
                dataGridViewGiamGia.Columns["EndDate"].HeaderText = "Ngày Kết Thúc";

                dataGridViewGiamGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshDataGridView()
        {
            List<GiamGiaDTO> offers = GiamGiaBLL.GetAllSpecialOffers();
            dataGridViewGiamGia.DataSource = offers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng SpecialOffer từ dữ liệu người dùng nhập
            GiamGiaDTO specialOffer = new GiamGiaDTO
            {
                OfferName = textBoxName.Text,
                Description = string.IsNullOrWhiteSpace(textBoxDescription.Text) ? null : textBoxDescription.Text,
                StartDate = dateTimePicker1.Value,
                EndDate = dateTimePicker2.Value,
                DiscountPercentage = string.IsNullOrWhiteSpace(textBoxDiscount.Text)
                    ? (decimal?)null
                    : decimal.Parse(textBoxDiscount.Text)
            };

            // Gọi service để thêm dữ liệu
            bool isSuccess = GiamGiaBLL.AddSpecialOffer(specialOffer);
            if (isSuccess)
            {
                MessageBox.Show("Thêm mã giảm giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGridView();

            }
            else
            {
                MessageBox.Show("Thêm mã giảm giá thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dataGridViewGiamGia.SelectedRows.Count > 0)
                {
                    // Lấy OfferId từ dòng được chọn
                    int selectedOfferId = Convert.ToInt32(dataGridViewGiamGia.SelectedRows[0].Cells["OfferId"].Value);

                    // Xác nhận trước khi xóa
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa mã giảm giá này?",
                                                        "Xác nhận xóa",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Gọi service để xóa dữ liệu
                        bool isDeleted = GiamGiaBLL.DeleteSpecialOffer(selectedOfferId);

                        if (isDeleted)
                        {
                            MessageBox.Show("Xóa mã giảm giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataGridView(); // Làm mới DataGridView sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Xóa mã giảm giá thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThanhToan thanhtoanForm = new ThanhToan();
            thanhtoanForm.Show();
        }
    }
}
