using Northwind.Api.Models;

namespace Northwind.Api.Repository.MySql
{
    public class OrderItemRepository : Repository<Orderitem>, IOrderItemRepository
    {
        public OrderItemRepository(NorthwindDbContext context) : base(context)
        {
        }
    }
}
