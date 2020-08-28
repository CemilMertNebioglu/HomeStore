using Store.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DTO
{
   public class ProductSupplierDTO 
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsinStock { get; set; }
    }
}
