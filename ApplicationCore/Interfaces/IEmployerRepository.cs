using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.Interfaces
{
    public interface IEmployerRepository : IRepository<Employer>
    {
        Task disable(string emp_id);
        Task activate(string emp_id);
        Task disable(Employer emp);
        Task activate(Employer emp);
    }
}