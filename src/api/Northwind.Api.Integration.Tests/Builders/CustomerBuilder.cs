using System;
using System.Collections.Generic;
using GenFu;
using Northwind.Api.Models;
using Northwind.Api.Repository.MySql;

namespace Northwind.Api.Integration.Tests.Builders
{
    public class CustomerBuilder
    {
        private readonly NorthwindDbContext _context;
        public CustomerBuilder(NorthwindDbContext context)
        {
            _context = context;            
        }

        public CustomerBuilder With10Customers()
        {
            AddCustomersToDbContext(CreateCustomer(10));
            return this;
        }

        public NorthwindDbContext Build()
        {
            return _context;
        }
        private void AddCustomersToDbContext(IEnumerable<Customer> customers)
        {
            _context.AddRange(customers);
            _context.SaveChanges();
        }

        private IEnumerable<Customer> CreateCustomer(int quantity)
        {
            int id= 1;
            GenFu.GenFu.Configure<Customer>()
            .Fill(c=> c.Id, () => { return id++; });

            return A.ListOf<Customer>(quantity);
        }
    }
}
