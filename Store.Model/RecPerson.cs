using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
   public class RecPerson : Entity<int>
    {
        public string Cv { get; set; }
    }
}
