using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        #region Customers Web API endpoints

        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <endpoint>
        /// GET /api/customers
        /// </endpoint>
        /// <returns>IEnumerable<Customer></returns>
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>));
        }

        /// <summary>
        /// Get Single Customers
        /// </summary>
        /// <endpoint>
        /// GET /api/customers/{id}
        /// </endpoint>
        /// <params>id</params>
        /// <returns>Customer</returns>
        public IHttpActionResult GetCustomers(int id)
        {
            Customer oCustomer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (oCustomer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(oCustomer));

        }

        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <endpoint>
        /// POST /api/customers
        /// </endpoint>
        /// <params>Customer</params>
        /// <returns>Customer</returns>
        [HttpPost]
        public IHttpActionResult CreateCustomers(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        /// <summary>
        /// Update Existing Customer
        /// </summary>
        /// <endpoint>
        /// PUT /api/customers/{id}
        /// </endpoint>
        /// <params>id</params>
        /// <params>Customer</params>
        [HttpPut]
        public IHttpActionResult UpdateCustomers(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Customer oCustomer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (oCustomer == null)
                return NotFound();

            Mapper.Map(customerDto, oCustomer);            

            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <endpoint>
        /// DELETE /api/customers/{id}
        /// </endpoint>
        /// <params>id</params>
        [HttpDelete]
        public IHttpActionResult DeleteCustomers(int id)
        {
            Customer oCustomer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (oCustomer == null)
                return NotFound();

            _context.Customers.Remove(oCustomer);
            _context.SaveChanges();
            return Ok();
        }
        #endregion
    }
}
