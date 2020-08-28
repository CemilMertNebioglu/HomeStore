using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DTO
{
   public class SupplierDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public List<Product> Products { get; set; }
    }
}
