using Northwind.Api.Models;

namespace Northwind.Api.Repository
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        bool Exist(int id);
    }
}
