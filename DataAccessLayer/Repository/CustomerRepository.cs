using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
     public class CustomerRepository : IRepository<Customer>
    {
        StoreDbContext _dbContext;
        public CustomerRepository(StoreDbContext storeDbContext)
        {
            _dbContext = storeDbContext;
        }

        // Creating New Customer
        public async Task<Customer> Create(Customer _object)
        {
            var obj = await _dbContext.Customers.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        //Deleting Customer 

        public void Delete(Customer _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }


        // Fetching all Customers Data

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return _dbContext.Customers.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        // Fetching a single customer data by customer ID

        public Customer GetById(int Id)
        {
            return _dbContext.Customers.Where(x => x.IsDeleted == false && x.CustomerId == Id).FirstOrDefault();
        }
        // Changing or Editing Customer Data
        public void Update(Customer _object)
        {
            _dbContext.Customers.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
