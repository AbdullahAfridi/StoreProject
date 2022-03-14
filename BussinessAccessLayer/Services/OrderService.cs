using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Services
{
 public class OrderService
    {

        private readonly IRepository<Order> _order;

        public OrderService(IRepository<Order> order)
        {
            _order = order;
        }
       
        //GET All Order Details   
        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                return _order.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //Add Order
        public async Task<Order> AddOrder(Order Order)
        {
            return await _order.Create(Order);
        }
        //Delete Order
        public bool DeleteOrder(int id)
        {

            try
            {
                var DataList = _order.GetAll().Where(x => x.OrderId == id).ToList();
                foreach (var item in DataList)
                {
                    _order.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Order Details  
        public bool UpdateOrder(Order order)
        {
            try
            {
                var DataList = _order.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _order.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
