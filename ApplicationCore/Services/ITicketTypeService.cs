using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
namespace ApplicationCore.Services
{
    public interface ITicketTypeService : IService<TicketType, TicketTypeDTO, TicketTypeDTO>
    {
        //query
        Task<TicketTypeDTO> getTicketTypeAsync(string ticketType_id);
        Task<IEnumerable<TicketTypeDTO>> getAllTicketTypeAsync();
        Task<IEnumerable<TicketTypeDTO>> getTicketTypeByNameAsync(string ticketType_name);
        //actions
        Task addTicketTypeAsync(TicketTypeDTO dto);
        Task removeTicketTypeAsync(string ticketType_id);
        Task updateTicketTypeAsync(TicketTypeDTO dto);
    }
}