using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GiamGiaDAL
    {
        private string connectionString = "Server=localhost,3306;Database=BaloShop;User ID=root;Password=adminpassword";

        // Phương thức lấy tất cả mã giảm giá
        public List<GiamGiaDTO> GetAllSpecialOffers()
        {
            List<GiamGiaDTO> specialOffers = new List<GiamGiaDTO>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT SpecialOfferID, Name, Description, StartDate, EndDate, DiscountPct FROM SpecialOffer", connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        specialOffers.Add(MapSpecialOffer(reader));
                    }
                }
            }

            return specialOffers;
        }

        // Map dữ liệu từ reader sang đối tượng SpecialOffer
        private GiamGiaDTO MapSpecialOffer(MySqlDataReader reader)
        {
            return new GiamGiaDTO
            {
                OfferId = reader.GetInt32("SpecialOfferID"),
                OfferName = reader.GetString("Name"),
                Description = reader.GetString("Description"),
                StartDate = reader.GetDateTime("StartDate"),
                EndDate = reader.GetDateTime("EndDate"),
                DiscountPercentage = reader.GetDecimal("DiscountPct")
            };
        }
        public bool AddSpecialOffer(GiamGiaDTO specialOffer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO SpecialOfferID 
                         (Name, Description, StartDate, EndDate, DiscountPct) 
                         VALUES (@OfferName, @Description, @StartDate, @EndDate, @DiscountPercentage)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Thêm tham số để tránh SQL Injection
                    command.Parameters.AddWithValue("@OfferName", specialOffer.OfferName);
                    command.Parameters.AddWithValue("@Description", specialOffer.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@StartDate", specialOffer.StartDate);
                    command.Parameters.AddWithValue("@EndDate", specialOffer.EndDate);
                    command.Parameters.AddWithValue("@DiscountPercentage", specialOffer.DiscountPercentage ?? (object)DBNull.Value);

                    int result = command.ExecuteNonQuery(); // Thực thi lệnh
                    return result > 0; // Trả về true nếu thêm thành công
                }
            }
        }
        public bool DeleteSpecialOffer(int offerId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM SpecialOffer WHERE OfferID = @OfferId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OfferId", offerId);

                    int result = command.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu xóa thành công
                }
            }
        }
    }
}
