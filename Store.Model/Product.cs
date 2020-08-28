using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
   public class Product : Entity<int>
    {
        public Product()
        {
            Dealers = new HashSet<Dealer>();
        }
        public string ProductName { get; set; }
 
        [ForeignKey("Category")]
        public Nullable<int> CategoryID { get; set; }
     
        public virtual Category Category { get; set; }
       
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public  bool Status { get; set; }
        public int SalesPoint { get; set; }
        public virtual ICollection<Dealer> Dealers { get; set; }
       

    }
}
