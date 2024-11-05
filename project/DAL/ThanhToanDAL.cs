using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;
using System.Data.SqlTypes;

namespace DAL
{
    public class ThanhToanDAL
    {
        private string connectionString = "Server=localhost;Database=baloshop;Uid=root;Pwd=;Port=3306;"; // Thay đổi thông tin kết nối phù hợp

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT ProductID, Name, ProductNumber, Color, Size, Weight, StandardCost, ListPrice, SafetyStockLevel, ProductSubCategory FROM Product", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ProductNumber = reader.GetString(2),
                        Color = reader.GetString(3),
                        Size = reader.GetString(4),
                        Weight = reader.GetDecimal(5),
                        StandardCost = reader.GetDecimal(6),
                        ListPrice = reader.GetDecimal(7),
                        SafetyStockLevel = reader.GetInt32(8),
                        ProductSubCategory = reader.GetString(9)
                    };
                    products.Add(product);
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
        public List<string> GetAllBrands()
        {
            List<string> brands = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT ProductSubCategory FROM Product"; // Lấy danh sách hãng duy nhất

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Thêm hãng vào danh sách
                            brands.Add(reader.GetString("ProductSubCategory"));
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
                    sql += " AND ProductSubCategory = @Brand";
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
                            var product = new Product
                            {
                                ProductID = reader.GetInt32("ProductID"),
                                Name = reader.GetString("Name"),
                                ProductNumber = reader.GetString("ProductNumber"),
                                Color = reader.IsDBNull(reader.GetOrdinal("Color")) ? null : reader.GetString("Color"),
                                Size = reader.IsDBNull(reader.GetOrdinal("Size")) ? null : reader.GetString("Size"),
                                Weight = reader.IsDBNull(reader.GetOrdinal("Weight")) ? 0 : reader.GetDecimal("Weight"),
                                StandardCost = reader.IsDBNull(reader.GetOrdinal("StandardCost")) ? 0 : reader.GetDecimal("StandardCost"),
                                ListPrice = reader.IsDBNull(reader.GetOrdinal("ListPrice")) ? 0 : reader.GetDecimal("ListPrice"),
                                SafetyStockLevel = reader.GetInt32("SafetyStockLevel"),
                                ProductSubCategory = reader.GetString("ProductSubCategory")
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
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
                            var product = new Product
                            {
                                ProductID = reader.GetInt32("ProductID"),
                                Name = reader.GetString("Name"),
                                ProductNumber = reader.GetString("ProductNumber"),
                                Color = reader.IsDBNull(reader.GetOrdinal("Color")) ? null : reader.GetString("Color"),
                                Size = reader.IsDBNull(reader.GetOrdinal("Size")) ? null : reader.GetString("Size"),
                                Weight = reader.IsDBNull(reader.GetOrdinal("Weight")) ? 0 : reader.GetDecimal("Weight"),
                                StandardCost = reader.IsDBNull(reader.GetOrdinal("StandardCost")) ? 0 : reader.GetDecimal("StandardCost"),
                                ListPrice = reader.IsDBNull(reader.GetOrdinal("ListPrice")) ? 0 : reader.GetDecimal("ListPrice"),
                                SafetyStockLevel = reader.GetInt32("SafetyStockLevel"),
                                ProductSubCategory = reader.GetString("ProductSubCategory")
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }



    }
}


