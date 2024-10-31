using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Database.DAL
{
    public class DatabaseAccess
    {
        private string connectionString = "Server=localhost ;Database=login ;User Id=root;Password=; Port=3306";
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        public bool CheckLogin(string username, string password)
        {
            string hashedInputPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT matkhau FROM user WHERE taikhoan=@Username";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    //cmd.Parameters.AddWithValue("@Password", hashedInputPassword);

                    //int result = (int)cmd.ExecuteScalar(); 
                    //return result > 0;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHashedPassword = reader.GetString("matkhau");
                            return hashedInputPassword == storedHashedPassword;
                        }
                    }
                    return false;
                    /*object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        int count = Convert.ToInt32(result);
                        return count > 0;
                    }
                    else
                    {
                        return false; 
                    }*/
                }
                catch (Exception ex)
                {
                    throw new Exception("Có lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
                }
            }
        }
        public void signupUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO user (taikhoan, matkhau) VALUES (@username, @password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Password stored successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
