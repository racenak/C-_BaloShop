using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        public bool Login(string username, string password)
        {
            // Có thể thêm logic mã hóa mật khẩu ở đây nếu cần.
            return userDAL.ValidateLogin(username, password);
        }
    }
}
