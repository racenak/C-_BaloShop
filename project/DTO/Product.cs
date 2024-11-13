using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ProductSubCategoryID { get; set; }
    }
}
