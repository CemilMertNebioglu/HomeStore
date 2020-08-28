using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
   public class Department : Entity<int>
    {
        public Department()
        {
            Orders = new HashSet<Order>();
        }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        [ForeignKey("Role")]
        public Nullable<int> RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
