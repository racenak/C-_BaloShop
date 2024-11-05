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
        }
    }

