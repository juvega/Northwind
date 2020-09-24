using System;
using Microsoft.OpenApi.Models;
using Northwind.Api.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Northwind.Api.Swagger
{
    public class RemoveDefinitionDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Components.Schemas.Remove(typeof(Customer).FullName);
            swaggerDoc.Components.Schemas.Remove(typeof(Orderitem).FullName);
            swaggerDoc.Components.Schemas.Remove(typeof(Order).FullName);
            swaggerDoc.Components.Schemas.Remove(typeof(Product).FullName);
            swaggerDoc.Components.Schemas.Remove(typeof(Supplier).FullName);
        }
    }
}
