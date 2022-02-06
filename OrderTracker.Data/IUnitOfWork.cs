using OrderTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderTracker.Data
{
    public interface IUnitOfWork
    {
        public bool AddCustomer(Customer customer);
        public IQueryable<Customer> GetCustomerById(int id);
    }
}
