using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderTracker.Data;
using OrderTracker.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderTrackerController : ControllerBase
    {


        private readonly ILogger<OrderTrackerController> _logger;
        private IUnitOfWork uow;

        public OrderTrackerController(ILogger<OrderTrackerController> logger, IUnitOfWork _uow)
        {
            _logger = logger;

            try
            {
                uow = _uow;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Gets a customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomersById/{id}")]
        public IQueryable<Customer> GetCustomerById(int id)
        {

            var result = uow.GetCustomerById(id);
            return result;
        }

        
        /// <summary>
        /// Adds a hardcoded customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCustomer")]
        public bool AddHardCodedCustomer()
        {
            Customer customer = new Customer()
            {
            
                FirstName = "George",
                LastName = "Lucas",
                StreetAddress = "123 Sesame Street",
                City = "New York City",
                ZIP = "11111",
                State = "NY",
                PhoneNumber = "1111111111",
                Email = "gl@skyguy.com"

            };

            var result = uow.AddCustomer(customer);

            return result;
        }



        /// <summary>
        /// Adds a customer manually
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCustomerMan")]
        //public bool AddManualCustomer(CustomerDto customerDto)
        public bool AddManualCustomer(Customer customerDto)
        {

            Customer customer = new Customer()
            {

                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                StreetAddress = customerDto.StreetAddress,
                City = customerDto.City,
                ZIP = customerDto.ZIP,
                State = customerDto.State,
                PhoneNumber = customerDto.PhoneNumber,
                Email = customerDto.Email

            };

            var result = uow.AddCustomer(customer);

            return result;
        }
    }
}
