using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Models
{
    public class ProductsViewModel
    {
        public List<ProductDTO> Products{ get; set; }
        public List<CategoryDTO> Categories{ get; set; }
        public List<SupplierDTO> Suppliers{ get; set; }
        public ProductDTO ProductDTO { get; set; }

    }
}
