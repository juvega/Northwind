using System;
using Alba;
using Northwind.Api.Repository.MySql;

namespace Northwind.Api.Integration.Tests
{
    public class WebApiFixture : IDisposable
    {
        public readonly SystemUnderTest systemUnderTest; 
        public readonly NorthwindDbContext northwindDbContext;           
        public WebApiFixture()
        {
            systemUnderTest = SystemUnderTest.ForStartup<Tests.Startup>();                                    
            northwindDbContext = (NorthwindDbContext)systemUnderTest.Services.GetService(typeof(NorthwindDbContext));
        }

        public void Dispose()
        {
            systemUnderTest?.Dispose();
            northwindDbContext?.Dispose();         
        }
    }
}
