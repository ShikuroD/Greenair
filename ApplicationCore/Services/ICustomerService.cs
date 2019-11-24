using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;
namespace ApplicationCore.Services
{
    public interface ICustomerService : IService<Customer, CustomerDTO, CustomerDTO>
    {
        //query
        Task getCustomer(string cus_id);
        Task getAllCustomer();
        Task<IEnumerable<Ticket>> getCustomerTicket(string cus_id);

        //actions
        Task orderTicket(string flight_id);
        Task payTicket(string flight_id, string ticket_id);
        Task cancelTicket(string flight_id, string ticket_id);
    }
}