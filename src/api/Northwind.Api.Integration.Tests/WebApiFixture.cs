using System;
using Alba;
using AutoMapper;
using Northwind.Api.Repository.MySql;

namespace Northwind.Api.Integration.Tests
{
    public class WebApiFixture : IDisposable
    {
        public readonly SystemUnderTest systemUnderTest; 
        public readonly NorthwindDbContext northwindDbContext;     
        public readonly IMapper mapper;      
        public WebApiFixture()
        {
            systemUnderTest = SystemUnderTest.ForStartup<Tests.Startup>();                                    
            northwindDbContext = (NorthwindDbContext)systemUnderTest.Services.GetService(typeof(NorthwindDbContext));
            mapper = (IMapper)systemUnderTest.Services.GetService(typeof(IMapper));
        }

        public void Dispose()
        {
            systemUnderTest?.Dispose();
            northwindDbContext?.Dispose();         
        }
    }
}
