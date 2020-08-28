using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
  public  class Order : Entity<int>
    {
       
        [ForeignKey("Customer")]
        public Nullable<int> CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Department")]

        public Nullable<int> DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
