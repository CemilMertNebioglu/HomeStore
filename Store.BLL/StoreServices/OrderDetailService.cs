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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitofWork _uow;

        public OrderDetailService(IUnitofWork uow)
        {
            _uow = uow;
            
        }
        public OrderDetailDTO addOrderDetail(OrderDetailDTO orderDetail)
        {
            var add = MapperFactory.CurrentMapper.Map<OrderDetail>(orderDetail);
            _uow.GetRepository<OrderDetail>().Add(add);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OrderDetailDTO>(add);
        }

        public bool deleteOrderDetail(int orderdetailId)
        {
            try
            {
                var delete = _uow.GetRepository<OrderDetail>().Get(z => z.Id == orderdetailId);
                _uow.GetRepository<OrderDetail>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<OrderDetailDTO> getAll()
        {
            var list = _uow.GetRepository<OrderDetail>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<OrderDetailDTO>>(list);
        }

        public OrderDetailDTO getOrderDetail(int orderdetailId)
        {
            var detail = _uow.GetRepository<OrderDetail>().Get(z => z.Id == orderdetailId);
            return MapperFactory.CurrentMapper.Map<OrderDetailDTO>(detail);

        }

        public  async Task<OrderDetailDTO> getOrderDetailAsync(int orderdetailId)
        {
            var detail =await _uow.GetRepository<OrderDetail>().GetAsync(z => z.Id == orderdetailId);
            return MapperFactory.CurrentMapper.Map<OrderDetailDTO>(detail);
        }

        public OrderDetailDTO updateOrderDetail(OrderDetailDTO orderDetail)
        {
            var update = _uow.GetRepository<OrderDetail>().Get(z => z.Id == orderDetail.Id);
            update = MapperFactory.CurrentMapper.Map<OrderDetail>(orderDetail);
            _uow.GetRepository<OrderDetail>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OrderDetailDTO>(update);
        }
    }
}
