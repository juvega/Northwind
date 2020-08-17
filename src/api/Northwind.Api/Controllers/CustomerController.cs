using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Models;
using Northwind.Api.Repository;

namespace Northwind.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return Ok(_repository.ReadAll());
        }
    }
}
