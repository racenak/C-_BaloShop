﻿using System;
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
                    products.Add(MapProduct(reader));
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
            product.ProductNumber = reader.GetString("ProductNumber");

            if (reader.IsDBNull(reader.GetOrdinal("Color")))
                product.Color = null;
            else
                product.Color = reader.GetString("Color");

            if (reader.IsDBNull(reader.GetOrdinal("Size")))
                product.Size = null;
            else
                product.Size = reader.GetString("Size");

            if (reader.IsDBNull(reader.GetOrdinal("Weight")))
                product.Weight = 0;
            else
                product.Weight = reader.GetDecimal("Weight");

            if (reader.IsDBNull(reader.GetOrdinal("StandardCost")))
                product.StandardCost = 0;
            else
                product.StandardCost = reader.GetDecimal("StandardCost");

            if (reader.IsDBNull(reader.GetOrdinal("ListPrice")))
                product.ListPrice = 0;
            else
                product.ListPrice = reader.GetDecimal("ListPrice");

            product.SafetyStockLevel = reader.GetInt32("SafetyStockLevel");
            product.ProductSubCategory = reader.GetString("ProductSubCategory");

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



    }
}


