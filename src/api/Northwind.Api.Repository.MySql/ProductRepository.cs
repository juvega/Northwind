using Northwind.Api.Models;

namespace Northwind.Api.Repository.MySql
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(NorthwindDbContext context) : base(context)
        {
        }
    }
}
