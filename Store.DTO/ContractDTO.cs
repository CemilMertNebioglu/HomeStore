using Store.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DTO
{
   public class ContractDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public  DateTime ContractDate { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }
    }
}
