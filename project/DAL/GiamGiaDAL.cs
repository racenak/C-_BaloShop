using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.GiamGiaDAL;
using DTO;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class GiamGiaDAL
    {
      

        private string connectionString = "Server=localhost;Port=3306;Database=_dbtest;User ID=root;Password=";

        // Phương thức lấy tất cả mã giảm giá
        public List<GiamGiaDTO> GetAllSpecialOffers()
        {
            List<GiamGiaDTO> specialOffers = new List<GiamGiaDTO>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT offer_id, offer_name, description, start_date, end_date, discount_percentage FROM special_offer", connection);

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
                OfferId = reader.GetInt32("offer_id"),
                OfferName = reader.GetString("offer_name"),
                Description = reader.GetString("description"),
                StartDate = reader.GetDateTime("start_date"),
                EndDate = reader.GetDateTime("end_date"),
                DiscountPercentage = reader.GetDecimal("discount_percentage")
            };
        }
        public bool AddSpecialOffer(GiamGiaDTO specialOffer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO special_offer 
                         (offer_name, description, start_date, end_date, discount_percentage) 
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
                string query = "DELETE FROM special_offer WHERE offer_id = @OfferId";
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
