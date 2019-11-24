using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task disable(string username);
        Task activate(string username);
    }
}