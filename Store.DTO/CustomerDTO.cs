using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DTO
{
   public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
