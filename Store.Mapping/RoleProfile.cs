using Store.DTO;
using Store.Mapping.ConfigProfile;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Mapping
{
   public class RoleProfile : ProfileBase
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
