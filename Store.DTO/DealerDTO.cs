using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DTO
{
   public class DealerDTO
    {
        public int Id { get; set; }
      
        public Nullable<int> ProductID { get; set; }
        public  ProductDTO product{ get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
    }
}
