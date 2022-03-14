using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Services
{
    public class CustomerService
    {

        private readonly IRepository<Customer> _customer;

        public CustomerService(IRepository<Customer> customer)
        {
            _customer = customer;
        }
        //Get Person Details By Customer email 
        public IEnumerable<Customer> GetCustomerEmail(string email)
        {
            return _customer.GetAll().Where(x => x.Email == email).ToList();
        }
        //GET All Customers Details   
        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                return _customer.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Customer by Customer Name  
        public Customer GetCustomersByName(string UserName)
        {
            return _customer.GetAll().Where(x => x.CustomerName == UserName).FirstOrDefault();
        }
        //Add Customer
        public async Task<Customer> AddCustomer(Customer Customer)
        {
            return await _customer.Create(Customer);
        }

       
        //Delete Customer  
        public bool DeleteCustomer(string UserEmail)
        {

            try
            {
                var DataList = _customer.GetAll().Where(x => x.Email == UserEmail).ToList();
                foreach (var item in DataList)
                {
                    _customer.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Customer Details  
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var DataList = _customer.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _customer.Update(item);
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
