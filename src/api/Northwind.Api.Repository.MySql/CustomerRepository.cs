using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.Models;

namespace Northwind.Api.Repository.MySql
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindDbContext context) : base(context)
        {
        }

        public bool Exist(int id)
        {
            return _context.Customer.AsNoTracking().FirstOrDefault(c => c.Id == id) != null;
        }
    }
}
