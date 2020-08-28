using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Models
{
    public class OrdersViewModel
    {
        public List<OrderDTO> Orders { get; set; }
        public List<OrderDetailDTO> Details { get; set; }
    }
}
