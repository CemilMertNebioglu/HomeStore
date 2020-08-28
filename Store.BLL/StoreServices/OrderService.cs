using Store.BLL.Abstract;
using Store.Core.Data.UnitofWork;
using Store.DTO;
using Store.Mapping.ConfigProfile;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.StoreServices
{
    public class OrderService : IOrderService
    {
        private readonly IUnitofWork _uow;
        public OrderService(IUnitofWork uow)
        {
            _uow = uow;
            
        }
        public OrderDTO addOrder(OrderDTO order)
        {
            var add = MapperFactory.CurrentMapper.Map<Order>(order);
            _uow.GetRepository<Order>().Add(add);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OrderDTO>(add);
        }

        public bool deleteOrder(int orderId)
        {
            try
            {
                var delete = _uow.GetRepository<Order>().Get(z => z.Id == orderId);
                _uow.GetRepository<Order>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<OrderDTO> getAll()
        {
            var list = _uow.GetRepository<Order>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<OrderDTO>>(list);
        }

        public OrderDTO getOrder(int orderId)
        {
            var order = _uow.GetRepository<Order>().Get(z => z.Id == orderId);
            return MapperFactory.CurrentMapper.Map<OrderDTO>(order);
        }

        public  async Task<OrderDTO> getOrdersAsync(int orderId)
        {
            var order =await _uow.GetRepository<Order>().GetAsync(z => z.Id == orderId);
            return MapperFactory.CurrentMapper.Map<OrderDTO>(order);
        }

        public OrderDTO updateOrder(OrderDTO order)
        {
            var update = _uow.GetRepository<Order>().Get(z => z.Id == order.Id);
            update = MapperFactory.CurrentMapper.Map<Order>(order);
            _uow.GetRepository<Order>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OrderDTO>(update);
        }
    }
}
