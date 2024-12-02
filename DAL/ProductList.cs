using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ProductList
    {
        private string connectionString = "server=localhost,3306;database=BaloShop;user=root;password=adminpassword;";

        public DataTable GetAllProducts()
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT ProductID, Name, Color, StandardCost, ListPrice, Size FROM Product";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public void AddProduct(string name, string color, decimal standardCost, decimal listPrice, string size)
        {
            string query = "INSERT INTO Products (Name, Color, StandardCost, ListPrice, Size) VALUES (@Name, @Color, @StandardCost, @ListPrice, @Size)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Color", color);
                    command.Parameters.AddWithValue("@StandardCost", standardCost);
                    command.Parameters.AddWithValue("@ListPrice", listPrice);
                    command.Parameters.AddWithValue("@Size", size);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(int productId, string name, string color, decimal standardCost, decimal listPrice, string size)
        {
            string query = "UPDATE Products SET Name = @Name, Color = @Color, StandardCost = @StandardCost, ListPrice = @ListPrice, Size = @Size WHERE ProductID = @ProductID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Color", color);
                    command.Parameters.AddWithValue("@StandardCost", standardCost);
                    command.Parameters.AddWithValue("@ListPrice", listPrice);
                    command.Parameters.AddWithValue("@Size", size);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            string query = "DELETE FROM Products WHERE ProductID = @ProductID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
