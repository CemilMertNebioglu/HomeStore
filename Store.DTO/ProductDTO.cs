using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DTO
{
  public  class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
      
        public Nullable<int> CategoryID { get; set; }

        public  CategoryDTO CategoryDTO { get; set; }

        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Status { get; set; }
        public int SalesPoint { get; set; }

        public List<Dealer> Dealers { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}
