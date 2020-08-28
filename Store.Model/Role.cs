using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Model
{
   public class Role : Entity<int>
    {
        public string Name { get; set; }
        public int Password { get; set; }
        public Department Department { get; set; }
    }
}
