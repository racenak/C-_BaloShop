using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ThanhToanBLL
    {
        private ThanhToanDAL thanhToanDAL = new ThanhToanDAL();


        public List<Product> GetAllProducts()
        {
            return thanhToanDAL.GetAllProducts();
        }



        public DataTable ConvertToDataTable(List<Product> products)
        {
            DataTable dataTable = new DataTable(typeof(Product).Name);

            // Lấy tất cả các thuộc tính của lớp Product và tạo các cột tương ứng trong DataTable
            PropertyInfo[] properties = typeof(Product).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // Thêm các cột vào DataTable với tên và kiểu dữ liệu của các thuộc tính trong Product
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Thêm từng đối tượng Product vào DataTable
            foreach (Product product in products)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(product, null) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
        public List<string> GetAllColors()
        {

            return thanhToanDAL.GetAllColors(); // Gọi phương thức từ DAL
        }

        // Phương thức lấy danh sách hãng
        public List<int> GetAllBrands()
        {
            return thanhToanDAL.GetAllBrands(); // Gọi phương thức từ DAL
        }



        public List<Product> SearchProducts(string brand, string color, decimal? minPrice, decimal? maxPrice)
        {
            return thanhToanDAL.SearchProducts(brand, color, minPrice, maxPrice);
        }



        public List<Product> SearchProductsByName(string productName)
        {
            return thanhToanDAL.SearchProductsByName(productName);
        }
        public decimal CalculateTotalPrice(List<Product> selectedProducts)
        {
            decimal totalPrice = 0;
            foreach (var product in selectedProducts)
            {
                totalPrice += product.ListPrice;
            }
            return totalPrice;
        }

        public int CountTotalProducts(List<Product> selectedProducts)
        {
            return selectedProducts.Count;
        }

        // Xử lý thanh toán và tạo đơn hàng
        public void ProcessPayment(int salePersonID, List<SaleOrderDetail> saleOrderDetails)
        {
            decimal subTotal = 0;
            decimal tax = 0;
            decimal totalDue = 0;

            // Tính toán subTotal, tax và totalDue
            foreach (var detail in saleOrderDetails)
            {
                subTotal += detail.UnitPrice * detail.Quantity;
            }
            tax = subTotal * 0.1m;  // Giả sử thuế là 10%
            totalDue = subTotal + tax;

            // Thêm đơn hàng vào bảng SaleOrderHeader
            int saleOrderID = thanhToanDAL.AddSaleOrderHeader(salePersonID, subTotal, tax, totalDue);

            // Thêm chi tiết đơn hàng vào bảng SaleOrderDetail
            foreach (var detail in saleOrderDetails)
            {
                thanhToanDAL.AddSaleOrderDetail(saleOrderID, detail.ProductID, detail.UnitPrice, detail.Quantity);

                // Cập nhật số lượng kho
                thanhToanDAL.UpdateProductInventory(detail.ProductID, detail.Quantity);
            }

            Console.WriteLine($"Payment processed successfully. Sale Order ID: {saleOrderID}");
        }
    }
}
