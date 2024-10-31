using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.DAL;

namespace DangNhap.BUS
{
    public class DangNhapBUS
    {
        private DatabaseAccess dal = new DatabaseAccess();

        public bool Login(string username, string password)
        {
            return dal.CheckLogin(username, password);
        }
    }
}
