using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
   public class OrderDetail : Entity<int>
    {
         
        [ForeignKey("Product")]
        public Nullable<int> ProductID { get; set; }
        public virtual Product Product { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
