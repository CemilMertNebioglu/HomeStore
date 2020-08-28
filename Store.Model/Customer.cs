using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
   public class Customer : Entity<int>
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City{ get; set; }
        public string Region{ get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public  virtual ICollection<Order> Orders { get; set; }

    }
}
