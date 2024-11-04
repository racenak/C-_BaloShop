using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Reflection;
namespace BLL

{
    public class ThanhToanBLL

    {
        private ThanhToanDAL thanhToanDAL = new ThanhToanDAL();

        public List<Product> GetAllProducts()
        {
            return thanhToanDAL.GetAllProducts();
        }



        public DataTable ConvertToDataTable(List<Product> products)
        {
            DataTable dataTable = new DataTable(typeof(Product).Name);

            // Lấy tất cả các thuộc tính của lớp Product và tạo các cột tương ứng trong DataTable
            PropertyInfo[] properties = typeof(Product).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // Thêm các cột vào DataTable với tên và kiểu dữ liệu của các thuộc tính trong Product
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Thêm từng đối tượng Product vào DataTable
            foreach (Product product in products)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(product, null) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

    }
}
