using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DTO
{
   public class OrderDTO
    {
        public int Id { get; set; }
     
        public Nullable<int> CustomerID { get; set; }
        public  CustomerDTO CustomerDTO { get; set; }
     

        public Nullable<int> DepartmentID { get; set; }
        public DepartmentDTO DepartmentDTO { get; set; }
        public OrderDetailDTO OrderDetailDTO { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
