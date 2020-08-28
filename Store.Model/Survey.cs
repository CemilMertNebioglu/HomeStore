using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Survey : Entity<int>
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
