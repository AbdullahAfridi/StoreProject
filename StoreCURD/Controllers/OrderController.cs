using BussinessAccessLayer.Services;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace StoreCURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        private readonly IRepository<Order> _Order;

        public OrderController(IRepository<Order> Order, OrderService ProductService)
        {
            _orderService = ProductService;
            _Order = Order;

        }
        //Add Order 
        [HttpPost("AddOrder")]
        public async Task<Object> AddOrder([FromBody] Order order)
        {
            try
            {
                await _orderService.AddOrder(order);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Order
        [HttpDelete("DeleteOrder")]
        public bool DeleteOrder(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Order
        [HttpPut("UpdateOrder")]
        public bool UpdateOrder(Order Object)
        {
            try
            {
                _orderService.UpdateOrder(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
      

        //GET All Order 
        [HttpGet("GetAllOrders")]
        public Object GetAllPersons()
        {
            var data = _orderService.GetAllOrders();
            var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}


