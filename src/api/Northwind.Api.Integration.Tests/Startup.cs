using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Api.Repository;
using Northwind.Api.Repository.MySql;

namespace Northwind.Api.Integration.Tests
{
    public class Startup
    {        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration {get;}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(Api.Controllers.CustomerController).Assembly);

            services.AddDbContext<NorthwindDbContext>(opt => opt.UseInMemoryDatabase("MySqlDbInMemory"));

            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NorthwindDbContext context)
        {            
            context.Database.EnsureCreated();
                        
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            }); 
        }

    }
}
