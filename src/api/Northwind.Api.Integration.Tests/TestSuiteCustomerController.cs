using System;
using System.Collections.Generic;
using System.Net;
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
        
        #region Get Tests
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

        [Fact]
        public async Task Verify_GetAllCustomers_204ResponseCode()
        {
            //Given            
            new CustomerBuilder(_context);
            //When
            await _system.Scenario(s =>
            {
                s.Get.Url("/api/customer");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.NoContent);
            });
        }

        [Fact]
        public async Task Verify_GetCustomer_200ResponseCode()
        {
            //Given            
            int customerId = int.MaxValue-1;
            new CustomerBuilder(_context).WithOneCustomerAndIdValue(customerId);
            //When
            var results = await _system.GetAsJson<Customer>($"/api/customer/{customerId}");
            //Then
            results.Id.Should().Be(customerId);
        }

        [Fact]
        public async Task Verify_GetCustomer_400ResponseCode()
        {
            //Given            
            new CustomerBuilder(_context);
            //When
            await _system.Scenario(s =>
            {
                s.Get.Url("/api/customer/-1");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.BadRequest);
            });
        }

        [Fact]
        public async Task Verify_GetCustomer_404ResponseCode()
        {
            //Given            
            new CustomerBuilder(_context);
            //When
            await _system.Scenario(s =>
            {
                s.Get.Url("/api/customer/2020");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.NotFound);
            });
        }
        #endregion

        #region Post Tests
        [Fact]
        public async Task Verify_PostCustomer_201ResponseCode()
        {
            //Given            
            var customer = A.New<Customer>();
            new CustomerBuilder(_context);
            //When
            await _system.Scenario(s =>
            {
                s.Post.Json(customer).ToUrl("/api/customer");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.Created);
            });
        }

        [Fact]
        public async Task Verify_PostCustomer_400ResponseCode()
        {
            //Given         
            Customer customer = null;
            //When
            await _system.Scenario(s =>
            {
                s.Post.Json(customer).ToUrl("/api/customer");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.BadRequest);
            });
        }

        #endregion

        #region Put Tests
        [Fact]
        public async Task Verify_PutCustomer_400ResponseCode()
        {
            //Given         
            Customer customer = null;
            //When
            await _system.Scenario(s =>
            {
                s.Put.Json(customer).ToUrl("/api/customer");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.BadRequest);
            });
        }

        [Fact]
        public async Task Verify_PutCustomer_204ResponseCode()
        {
            //Given         
            Customer customer = new Customer { Id = int.MaxValue };
            //When
            await _system.Scenario(s =>
            {
                s.Put.Json(customer).ToUrl("/api/customer");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.NoContent);
            });
        }

        [Fact]
        public async Task Verify_PutCustomer_200ResponseCode()
        {
            //Given         
            var customer = A.New<Customer>();
            customer.Id= int.MaxValue-2;

            new CustomerBuilder(_context).WithSpecificCustomer(customer);
            
            var result = await _system.PutJson(customer,"/api/customer").Receive<Customer>();
            //Then
            result.Should().BeEquivalentTo(customer);
        }
        #endregion
        #region Delete Tests
        [Fact]
        public async Task Verify_DeleteCustomer_400ResponseCode()
        {
            //Given         
            
            //When
            await _system.Scenario(s =>
            {
                s.Delete.Url("/api/customer/-1");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.BadRequest);
            });
        }

        [Fact]
        public async Task Verify_DeleteCustomer_204ResponseCode()
        {
            //Given         
            
            //When
            await _system.Scenario(s =>
            {
                s.Delete.Url($"/api/customer/{int.MaxValue}");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.NoContent);
            });
        }

        [Fact]
        public async Task Verify_DeleteCustomer_200ResponseCode()
        {
            //Given         
            var customer = A.New<Customer>();

            new CustomerBuilder(_context).WithSpecificCustomer(customer);
            
            await _system.Scenario(s =>
            {
                s.Delete.Url($"/api/customer/{customer.Id}");

                //Then
                s.StatusCodeShouldBe(HttpStatusCode.OK);
            });
        }

        #endregion
    }

}
