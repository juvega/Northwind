using System;
using Hellang.Middleware.ProblemDetails;

namespace Microsoft.AspNetCore.Builder
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNorthwind(this IApplicationBuilder app)        
        {
            app.UseProblemDetails();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            return app;
        }
    }
}
