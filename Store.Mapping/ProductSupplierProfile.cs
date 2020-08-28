using Store.DTO;
using Store.Mapping.ConfigProfile;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Mapping
{
   public class ProductSupplierProfile : ProfileBase
    {
        public ProductSupplierProfile()
        {
            CreateMap<ProductSupplier, ProductSupplierDTO>().ReverseMap();
        }
    }
}
