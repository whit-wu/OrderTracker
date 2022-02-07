using OrderTracker.Model;
using System;
using System.Linq;

namespace OrderTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private OrderTrackerContext _context;

        public UnitOfWork(OrderTrackerContext context)
        {
            _context = context;
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }


        public IQueryable<Customer> GetCustomerById(int id)
        {
            return _context.Customers.Where(c => c.Id == id);

           
            
        }
    }
}
