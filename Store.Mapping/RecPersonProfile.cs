﻿using Store.DTO;
using Store.Mapping.ConfigProfile;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Mapping
{
   public class RecPersonProfile : ProfileBase
    {
        public RecPersonProfile()
        {
            CreateMap<RecPerson, RecPersonDTO>().ReverseMap();
        }
    }
}
