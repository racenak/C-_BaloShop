using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BLL;

namespace BaloNe
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductListBLL productBLL = new ProductListBLL();

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable products = productBLL.GetProducts();
            dataGridView1.DataSource = products;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            string name = textBox1.Text;
            string color = textBox2.Text;
            decimal standardCost = Convert.ToDecimal(textBox3.Text);
            decimal listPrice = Convert.ToDecimal(textBox4.Text);
            string size = textBox5.Text;

            // Call BLL method to add product
            productBLL.AddProduct(name, color, standardCost, listPrice, size);

            // Reload data in DataGridView
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int productId) && productId > 0)
            {
                // Get values from textboxes
                string name = textBox1.Text;
                string color = textBox2.Text;
                decimal standardCost = Convert.ToDecimal(textBox3.Text);
                decimal listPrice = Convert.ToDecimal(textBox4.Text);
                string size = textBox5.Text;

                // Call BLL method to update product
                productBLL.UpdateProduct(productId, name, color, standardCost, listPrice, size);

                // Reload data in DataGridView
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int productId) && productId > 0)
            {
                // Call BLL method to delete product
                productBLL.DeleteProduct(productId);

                // Reload data in DataGridView
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox6.Text = row.Cells["ProductID"].Value.ToString();
                textBox1.Text = row.Cells["Name"].Value.ToString();
                textBox2.Text = row.Cells["Color"].Value.ToString();
                textBox3.Text = row.Cells["StandardCost"].Value.ToString();
                textBox4.Text = row.Cells["ListPrice"].Value.ToString();
                textBox5.Text = row.Cells["Size"].Value.ToString();
            }
        }

        // Di den thanh toan
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThanhToan thanhToanForm = new ThanhToan();
            thanhToanForm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGiamGia giamgiaForm = new FormGiamGia();
            giamgiaForm.Show();
        }
    }
}
