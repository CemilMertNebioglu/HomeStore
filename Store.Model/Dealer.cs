using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
   public class Dealer : Entity<int>
    {
    
        [ForeignKey("Product")]
        public Nullable<int> ProductID { get; set; }
        public virtual Product Product { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
    }
}
