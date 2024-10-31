using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.DAL;

namespace DangKy.BUS
{
    class DangKyBUS
    {
        private DatabaseAccess dal = new DatabaseAccess();

        public void Signup(string username, string password)
        {
            dal.signupUser(username, password);
        }
    }
}
