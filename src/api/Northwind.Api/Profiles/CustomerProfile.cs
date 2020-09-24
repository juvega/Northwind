using System;
using AutoMapper;
using Northwind.Api.Models;

namespace Northwind.Api.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Models.Dto.Customer, Customer>();
            CreateMap<Customer, Models.Dto.Customer>();
        }
    }
}
