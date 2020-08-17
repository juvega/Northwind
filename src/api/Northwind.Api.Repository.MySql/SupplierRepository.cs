using Northwind.Api.Models;

namespace Northwind.Api.Repository.MySql
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NorthwindDbContext context) : base(context)
        {
        }
    }
}
