using Store.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DTO
{
   public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
