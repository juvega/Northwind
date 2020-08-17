using Northwind.Api.Models;

namespace Northwind.Api.Repository.MySql
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindDbContext context) : base(context)
        {
        }
    }
}
