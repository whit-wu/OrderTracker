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
        private OrderTrackerContext _context;
        private string userId = "SYSTEM";
        private IUnitOfWork uow;

        public OrderTrackerController(ILogger<OrderTrackerController> logger)
        {
            _logger = logger;

            try
            {
                _context = new OrderTrackerContext(false);

                uow = new UnitOfWork(_context);
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
    }
}
