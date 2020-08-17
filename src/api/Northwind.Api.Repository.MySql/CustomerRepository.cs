using System;
using Northwind.Api.Models;

namespace Northwind.Api.Repository.MySql
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindDbContext context) : base(context)
        {
        }
    }
}
