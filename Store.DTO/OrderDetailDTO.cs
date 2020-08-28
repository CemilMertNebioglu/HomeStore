using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DTO
{
   public class OrderDetailDTO
    {
        public int Id { get; set; }

        public Nullable<int> ProductID { get; set; }
        public ProductDTO ProductDTO { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
