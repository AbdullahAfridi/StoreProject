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
    public class OrderRepository : IRepository<Order>
    {
        StoreDbContext _dbContext;
        public OrderRepository(StoreDbContext storeDbContext)
        {
            _dbContext = storeDbContext;
        }
        // Creating New Order

        public async Task<Order> Create(Order _object)
        {
            var obj = await _dbContext.Orders.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        //Deleting Order

        public void Delete(Order _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        // Fetching all Orders


        public IEnumerable<Order> GetAll()
        {
            try
            {
                return _dbContext.Orders.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        // Fetching single  Order

        public Order GetById(int Id)
        {
            return _dbContext.Orders.Where(x => x.IsDeleted == false && x.OrderId== Id).FirstOrDefault();
        }

        // Editing Order

        public void Update(Order _object)
        {
            _dbContext.Orders.Update(_object);
            _dbContext.SaveChanges();
        }

    }
}