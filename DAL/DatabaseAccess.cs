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
        private string connectionString = "Server=localhost ;Database=xisap ;User Id=root;Password=69215847; Port=3306";
        /*public static string HashPassword(string password)
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
        }*/
        public bool CheckLogin(string username, string password)
        {
            //string hashedInputPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PersonID FROM person WHERE FirstName=@Username";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    //cmd.Parameters.AddWithValue("@Password", hashedInputPassword);

                    //int result = (int)cmd.ExecuteScalar(); 
                    //return result > 0;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int personID = reader.GetInt32("PersonID");
                            reader.Close();
                            query = "SELECT PasswordHash FROM password WHERE PersonID = " + personID;
                            cmd = new MySqlCommand(query, conn);
                            using (MySqlDataReader reader1 = cmd.ExecuteReader())
                            {
                                if (reader1.Read())
                                {
                                    string storedHashedPassword = reader1.GetString("PasswordHash");
                                    return password == storedHashedPassword;
                                }

                            }
                        }
                        else return false;
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
        public bool signupUser(string username, string password, string lastname)
        {
            //string hashedPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
        
                    
                        string query = "INSERT INTO person (PersonType, FirstName, LastName, ModifiedDate) VALUES (@PersonType, @FirstName,@LastName,@Date)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    
                        //cmd.Parameters.AddWithValue("@PersonID", ID);
                        cmd.Parameters.AddWithValue("@PersonType", "Emp");
                        cmd.Parameters.AddWithValue("@FirstName", username);
                        cmd.Parameters.AddWithValue("@LastName", lastname);
                        cmd.Parameters.AddWithValue("Date", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    
                    string sql = "SELECT MAX(PersonID) AS LastID FROM person";
                    int ID = 1;
                    cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            ID = reader.GetInt32("LastID");
                        reader.Close();
                    }
                    query = "INSERT INTO password (PersonID, PasswordHash,ModifiedDate) VALUES (@PersonID, @PasswordHash, @Date)";
                    using(cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonID", ID);
                        cmd.Parameters.AddWithValue("@PasswordHash", password);
                        cmd.Parameters.AddWithValue("Date", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Password stored successfully!");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw new Exception( ex.Message);
                }
            }
        }
    }
}
