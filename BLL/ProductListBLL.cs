using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ProductListBLL
    {

        private readonly ProductList productlist = new ProductList();
        public DataTable GetProducts()
        {
            // Logic nghiệp vụ nếu cần
            return productlist.GetAllProducts();
        }

        public void AddProduct(string name, string color, decimal standardCost, decimal listPrice, string size)
        {
            productlist.AddProduct(name, color, standardCost, listPrice, size);
        }

        public void UpdateProduct(int productId, string name, string color, decimal standardCost, decimal listPrice, string size)
        {
            productlist.UpdateProduct(productId, name, color, standardCost, listPrice, size);
        }

        public void DeleteProduct(int productId)
        {
            productlist.DeleteProduct(productId);
        }

    }
}
