using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Models;
using Northwind.Api.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace Northwind.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation("Get Customer", "List of customers from database")]
        [SwaggerResponse((int)HttpStatusCode.OK, "List of customers", typeof(IEnumerable<Models.Dto.Customer>))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "No customers")]
        public ActionResult<IEnumerable<Models.Dto.Customer>> GetAllCustomers()
        {
            var result = _repository.ReadAll();
            if (!result.Any()) return NoContent();
            return Ok(_mapper.Map<IEnumerable<Models.Dto.Customer>>(result));
        }

        [HttpGet("{id:int}", Name = "GetCustomer")]
        [SwaggerOperation("Get a Customer", "Specific customer from database")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Customer by id", typeof(Models.Dto.Customer))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "No customer")]
        public ActionResult<Models.Dto.Customer> GetCustomer([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();

            var result = _repository.Read(id);
            if (result == null) return NotFound();
            return Ok(_mapper.Map<Models.Dto.Customer>(result));
        }

        [HttpPost]
        [SwaggerOperation("Create Customer", "Create a a new Customer")]
        [SwaggerResponse((int)HttpStatusCode.Created, "Created a new customer", typeof(Models.Dto.Customer))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "There is some errors in the request")]
        public ActionResult<Models.Dto.Customer> Post([FromBody] Models.Dto.Customer customer)
        {
            if (customer == null) return BadRequest();

            _repository.Create(_mapper.Map<Customer>(customer));

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpPut]
        [SwaggerOperation("Update Customer", "Create a a new Customer")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "There is some errors in the request")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Customer not found")]        
        [SwaggerResponse((int)HttpStatusCode.OK, "Customer updated properly", typeof(Models.Dto.Customer))]
        public ActionResult<Models.Dto.Customer> Put([FromBody] Models.Dto.Customer customer)
        {
            if (customer == null) return BadRequest();


            if (!_repository.Exist(customer.Id)) return NoContent();

            _repository.Update(_mapper.Map<Customer>(customer));            

            return Ok(customer);
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation("Delete Customer", "Delete an existent Customer")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "There is some errors in the request")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Customer not found")]        
        [SwaggerResponse((int)HttpStatusCode.OK, "Customer deleted properly")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();

            var customer = _repository.Read(id);

            if (customer == null) return NoContent();

            _repository.Delete(customer);

            return Ok();
        }
    }
}
