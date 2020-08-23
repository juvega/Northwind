using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alba;
using FluentAssertions;
using GenFu;
using Northwind.Api.Integration.Tests.Builders;
using Northwind.Api.Models;
using Northwind.Api.Repository.MySql;
using Xunit;

namespace Northwind.Api.Integration.Tests
{
    public class TestSuiteCustomerController : IClassFixture<WebApiFixture>
    {
        private readonly SystemUnderTest _system;    
        private readonly NorthwindDbContext _context;    
        public TestSuiteCustomerController(WebApiFixture app)
        {
            _system = app.systemUnderTest;
            _context = app.northwindDbContext;            
        }        
        
        [Fact]
        public async Task Verify_GetAllCustomers_200ResponseCode_With_Data()
        {
            //Given            
            new CustomerBuilder(_context).With10Customers();
            //When
            var results = await _system.GetAsJson<IList<Customer>>("/api/customer");
            //Then
            results.Count.Should().Be(10);
        }
    }
    
}
