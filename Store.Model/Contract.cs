using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Model
{
   public class Contract : Entity<int>
    {
        public Contract()
        {
            Suppliers = new HashSet<Supplier>();
        }
        public string Title { get; set; }
        public  DateTime ContractDate { get; set; }
        public string Content { get; set; }
        [ForeignKey("Supplier")]
        public int  SupplierID { get; set; }
        public virtual ICollection<Supplier> Suppliers{ get; set; }
    }
}
