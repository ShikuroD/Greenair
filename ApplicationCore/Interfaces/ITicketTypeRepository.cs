using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.Interfaces
{
    public interface ITicketTypeRepository : IRepository<TicketType>
    {
        Task disable(string TicketType_id);
        Task activate(string TicketType_id);
        Task disable(TicketType acc);
        Task activate(TicketType acc);
    }
}