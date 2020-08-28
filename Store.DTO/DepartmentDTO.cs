using Store.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DTO
{
   public class DepartmentDTO
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        [ForeignKey("Role")]
        public Nullable<int> RoleId { get; set; }

        public  Role Role { get; set; }

        public List<Order> Orders { get; set; }
    }
}
