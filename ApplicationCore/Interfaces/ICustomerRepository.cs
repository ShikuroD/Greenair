using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>, IPersonBaseRepository<Customer>
    {

    }
}