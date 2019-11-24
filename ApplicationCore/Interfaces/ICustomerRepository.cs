using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task disable(string cus_id);
        Task activate(string cus_id);
        Task disable(Customer cus);
        Task activate(Customer cus);
    }
}