using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        private string connectionString = "server=localhost,3306;database=BaloShop;user=root;password=adminpassword;";

        public bool ValidateLogin(string username, string password)
        {
            bool isValid = false;
            string query = @"SELECT COUNT(*) 
                             FROM Person p
                             INNER JOIN Password pw ON p.PersonID = pw.PersonID
                             WHERE CONCAT(p.FirstName, ' ', p.LastName) = @username AND pw.Password = @password";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); // Mã hóa nếu cần

                    conn.Open();
                    isValid = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            return isValid;
        }
    }
}
