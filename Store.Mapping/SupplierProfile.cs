using Store.DTO;
using Store.Mapping.ConfigProfile;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Mapping
{
   public class SupplierProfile : ProfileBase
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
        }
    }
}
