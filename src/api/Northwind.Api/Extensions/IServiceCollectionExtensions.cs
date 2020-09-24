using System;
using AutoMapper;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.Profiles;
using Northwind.Api.Repository;
using Northwind.Api.Repository.MySql;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddNorthwindDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository,CustomerRepository>();
            services.AddAutoMapper(typeof(CustomerProfile));

            services.AddProblemDetails(opt =>
            {
                opt.IncludeExceptionDetails = (ctx, ex) => false;
                opt.ShouldLogUnhandledException = (ctx, ex, details) => true;
                opt.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
            });
            return services;
        }

        public static IServiceCollection AddHostDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddControllers();
            services.AddDbContext<NorthwindDbContext>(opt=> 
                opt.UseMySql(connectionString, x => x.ServerVersion("8.0.21-mysql"))
            );

            services.AddSwaggerGen(configuration=>
            {
                configuration.EnableAnnotations();
                configuration.CustomSchemaIds(type=>type.Name);   
                //configuration.DocumentFilter<RemoveDefinitionDocumentFilter>();
            }); 
            return services;
        }
    }
}
