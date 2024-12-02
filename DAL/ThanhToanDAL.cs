using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ThanhToanDAL
    {
        private string connectionString = "Server=localhost,3306;Database=BaloShop;User ID=root;Password=adminpassword;"; // Thay đổi thông tin kết nối phù hợp

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT ProductID, Name, Color, Size, StandardCost, ListPrice, SafetyStockLevel, ProductSubCategoryID FROM Product", connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(MapProduct(reader));
                    }
                }
            }

            return products;
        }



        // Phương thức lấy danh sách màu sắc
        public List<string> GetAllColors()
        {
            List<string> colors = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Color FROM Product"; // Lấy danh sách màu sắc duy nhất

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Thêm màu sắc vào danh sách
                            colors.Add(reader.GetString("Color"));
                        }
                    }
                }
            }

            return colors;
        }

        // Phương thức lấy danh sách hãng
        public List<int> GetAllBrands()
        {
            List<int> brands = new List<int>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT ProductSubCategoryID FROM Product"; // Lấy danh sách hãng duy nhất

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Thêm hãng vào danh sách
                            brands.Add(reader.GetInt32("ProductSubCategoryID"));
                        }
                    }
                }
            }

            return brands;
        }
        public List<Product> SearchProducts(string brand, string color, decimal? minPrice, decimal? maxPrice)
        {
            var products = new List<Product>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Câu lệnh SQL động
                string sql = "SELECT * FROM Product WHERE 1=1";

                if (!string.IsNullOrEmpty(brand))
                    sql += " AND ProductSubCategoryID = @Brand";
                if (!string.IsNullOrEmpty(color))
                    sql += " AND Color = @Color";
                if (minPrice.HasValue)
                    sql += " AND ListPrice >= @MinPrice";
                if (maxPrice.HasValue)
                    sql += " AND ListPrice <= @MaxPrice";


                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    if (!string.IsNullOrEmpty(brand))
                        command.Parameters.AddWithValue("@Brand", brand);
                    if (!string.IsNullOrEmpty(color))
                        command.Parameters.AddWithValue("@Color", color);
                    if (minPrice.HasValue)
                        command.Parameters.AddWithValue("@MinPrice", minPrice.Value);
                    if (maxPrice.HasValue)
                        command.Parameters.AddWithValue("@MaxPrice", maxPrice.Value);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(MapProduct(reader));
                        }
                    }
                }
            }

            return products;
        }

        // Helper function to map data from reader to ProductDTO
        private Product MapProduct(MySqlDataReader reader)
        {
            var product = new Product();

            product.ProductID = reader.GetInt32("ProductID");
            product.Name = reader.GetString("Name");

            if (reader.IsDBNull(reader.GetOrdinal("Color")))
                product.Color = null;
            else
                product.Color = reader.GetString("Color");

            if (reader.IsDBNull(reader.GetOrdinal("Size")))
                product.Size = null;
            else
                product.Size = reader.GetString("Size");



            if (reader.IsDBNull(reader.GetOrdinal("StandardCost")))
                product.StandardCost = 0;
            else
                product.StandardCost = reader.GetDecimal("StandardCost");

            if (reader.IsDBNull(reader.GetOrdinal("ListPrice")))
                product.ListPrice = 0;
            else
                product.ListPrice = reader.GetDecimal("ListPrice");

            product.SafetyStockLevel = reader.GetInt32("SafetyStockLevel");
            product.ProductSubCategoryID = reader.GetInt32("ProductSubCategoryID");

            return product;
        }


        public List<Product> SearchProductsByName(string productName)
        {
            var products = new List<Product>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Câu lệnh SQL tìm kiếm theo tên sản phẩm
                string sql = "SELECT * FROM Product WHERE Name LIKE @ProductName";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", $"%{productName}%");

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(MapProduct(reader));
                        }
                    }
                }
            }

            return products;
        }

        // Thêm đơn hàng vào bảng SaleOrderHeader
        public int AddSaleOrderHeader(int salePersonID, decimal subTotal, decimal tax, decimal totalDue)
        {
            int saleOrderID = 0;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO SalesOrderHeader (SalePersonID, Status, SubTotal, Tax, TotalDue) " +
                               "VALUES (@SalePersonID, @Status, @SubTotal, @Tax, @TotalDue); " +
                               "SELECT LAST_INSERT_ID();";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SalePersonID", salePersonID);
                command.Parameters.AddWithValue("@Status", 1);
                command.Parameters.AddWithValue("@SubTotal", subTotal);
                command.Parameters.AddWithValue("@Tax", tax);
                command.Parameters.AddWithValue("@TotalDue", totalDue);

                connection.Open();
                saleOrderID = Convert.ToInt32(command.ExecuteScalar());
            }
            return saleOrderID;
        }

        // Thêm đơn hàng vào bảng SaleOrderDetail
        public void AddSaleOrderDetail(int saleOrderID, int productID, decimal unitPrice, int quantity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO SalesOrderDetail (SaleOrderID, ProductID, UnitPrice, OrderQty) " +
                               "VALUES (@SaleOrderID, @ProductID, @UnitPrice, @Quantity)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SaleOrderID", saleOrderID);
                command.Parameters.AddWithValue("@ProductID", productID);
                command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                command.Parameters.AddWithValue("@Quantity", quantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Cập nhật số lượng kho
        public void UpdateProductInventory(int productID, int quantity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE ProductInventory SET Quantity = Quantity - @Quantity WHERE ProductID = @ProductID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productID);
                command.Parameters.AddWithValue("@Quantity", quantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
