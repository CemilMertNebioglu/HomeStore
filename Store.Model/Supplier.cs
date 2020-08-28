using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
   public class Supplier : Entity<int>
    {
        
        public string CompanyName { get; set; }
        public string Adress  { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public Contract Contract { get; set; }

    }
}
