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

namespace StoreCURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        private readonly IRepository<Customer> _Customer;

        public CustomerController(IRepository<Customer> Customer, CustomerService ProductService)
        {
            _customerService = ProductService;
            _Customer = Customer;

        }
        //Add Customer 
        [HttpPost("AddCustomer")]
        public async Task<Object> AddCustomer([FromBody] Customer customer)
        {
            try
            {
                await _customerService.AddCustomer(customer);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Customer  
        [HttpDelete("DeleteCustomer")]
        public bool DeleteCustomer(string UserEmail)
        {
            try
            {
                _customerService.DeleteCustomer(UserEmail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Customer
        [HttpPut("UpdateCustomer")]
        public bool UpdateCustomer(Customer Object)
        {
            try
            {
                _customerService.UpdateCustomer(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //GET All Customer by Name  
        [HttpGet("GetAllCustomersByName")]
        public Object GetAllCustomerByName(string  UserName)
        {
            var data = _customerService.GetCustomersByName(UserName);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Customers 
        [HttpGet("GetAllCustomers")]
        public Object GetAllCustomers()
        {
            var data = _customerService.GetAllCustomers();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
