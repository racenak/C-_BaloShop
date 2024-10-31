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
    public partial class FormchitietDH : Form
    {
        public FormchitietDH()
        {
            InitializeComponent();
            taoBang();
        }

        private void taoBang() {
            detailTable.Columns.Clear();
            detailTable.Columns.Add("productId", "ID");
            detailTable.Columns.Add("product_name", "Name");
            detailTable.Columns.Add("product_quantity", "Quantity");
            detailTable.Columns.Add("product_price", "Price");
            detailTable.Columns["productId"].Width = 200;
            detailTable.Columns["product_quantity"].Width = 200;
            detailTable.Columns["product_name"].Width = 200;
            detailTable.Columns["product_price"].Width = 200;
            detailTable.Rows.Add("11", "dai", "tenanh", "thieukia");
        }

        private void detailTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
