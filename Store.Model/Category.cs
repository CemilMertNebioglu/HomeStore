using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Category : Entity<int>
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public int? ParentCategoryID { get; set; }

        public virtual Category ParentCategory { get; set; }

    }
}
    