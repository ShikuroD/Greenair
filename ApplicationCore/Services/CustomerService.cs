using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System;
using LinqKit;
namespace ApplicationCore.Services
{
    public class CustomerService : Service<Customer, CustomerDTO, CustomerDTO>, ICustomerService
    {
        protected readonly IAccountService accountService;
        public CustomerService(IUnitOfWork _unitOfWork, IMapper _mapper, IAccountService _account) : base(_unitOfWork, _mapper)
        {
            accountService = _account;
        }
        //query
        public async Task<CustomerDTO> getCustomerAsync(string cus_id)
        {
            var cus = await unitOfWork.Customers.GetByAsync(cus_id);
            Console.WriteLine("qwerty {0}", cus.FullName);
            if (cus == null) return null;
            return toDto(cus);
        }
        public async Task<IEnumerable<CustomerDTO>> getAllCustomerAsync()
        {
            return toDtoRange(await unitOfWork.Customers.GetAllAsync());
        }
        public async Task<IEnumerable<TicketDTO>> getCustomerTicketAsync(string cus_id)
        {
            var predicate = PredicateBuilder.New<Ticket>();
            predicate = predicate.And(m => m.CustomerId.Equals(cus_id));
            var tickets = await unitOfWork.Flights.findTicketAsync(predicate);
            return mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<IEnumerable<CustomerDTO>> getCustomerByName(string lastname, string firstname)
        {
            return this.toDtoRange(await unitOfWork.Customers.getCustomerByName(lastname, firstname));
        }
        public async Task<IEnumerable<CustomerDTO>> getCustomerByName(string fullname)
        {
            return this.toDtoRange(await unitOfWork.Customers.getCustomerByName(fullname));
        }






        //actions
        public async Task orderTicketAsync(string flight_id, string cus_id, string assined_cus, string ticket_type_id)
        {
            var tickets = await unitOfWork.Flights.getAvailableTickets(flight_id);
            if (tickets.Count() >= 1)
            {
                var ticket = tickets.ElementAt(0);
                await unitOfWork.Flights.orderTicket(ticket, cus_id, assined_cus, ticket_type_id);
            }
        }
        public async Task orderTicketRangeAsync(string flight_id, int adult_num, int child_num, string cus_id)
        {
            int sum = adult_num + child_num;
            var tickets = await unitOfWork.Flights.getAvailableTickets(flight_id);
            if (tickets.Count() >= sum)
            {
                for (int i = 0; i < sum; i++)
                {
                    if (i < adult_num)
                    {
                        await unitOfWork.Flights.orderTicket(tickets.ElementAt(i), cus_id, null, "000");
                    }
                    else
                    {
                        await unitOfWork.Flights.orderTicket(tickets.ElementAt(i), cus_id, null, "001");
                    }
                }
            }
        }
        public async Task payTicketAsync(string flight_id, string ticket_id)
        {
            var ticket = await unitOfWork.Flights.getTicket(flight_id, ticket_id);
            if (ticket != null && ticket.Status == STATUS.ORDERED)
            {
                await unitOfWork.Flights.paidTicket(ticket);
            }
        }
        public async Task cancelTicketAsync(string flight_id, string ticket_id)
        {
            var ticket = await unitOfWork.Flights.getTicket(flight_id, ticket_id);
            if (ticket != null && ticket.Status == STATUS.ORDERED)
            {
                await unitOfWork.Flights.cancelTicket(ticket);
            }
        }

        private async Task generateCustomerIDAsync(Customer cus)
        {
            if (String.IsNullOrEmpty(cus.Id))
            {
                var res = await unitOfWork.Customers.GetAllAsync();
                cus.Id = String.Format("{0:00000}", res.Count());
            }

        }
        public async Task addCustomerAsync(CustomerDTO dto)
        {
            if (await unitOfWork.Customers.GetByAsync(dto.Id) == null)
            {
                var cus = this.toEntity(dto);
                await this.generateCustomerIDAsync(cus);
                await unitOfWork.Customers.AddAsync(cus);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task removeCustomerAsync(string cus_id)
        {
            var cus = await unitOfWork.Customers.GetByAsync(cus_id);
            if (cus != null)
            {
                await unitOfWork.Customers.RemoveAsync(cus);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task updateCustomerAsync(CustomerDTO dto)
        {
            if (await unitOfWork.Customers.GetByAsync(dto.Id) != null)
            {
                var cus = this.toEntity(dto);
                await unitOfWork.Customers.UpdateAsync(cus);
            }
            else
            {
                var cus = this.toEntity(dto);
                await unitOfWork.Customers.UpdateAsync(cus);
            }
            await unitOfWork.CompleteAsync();
        }

        public async Task createAccountAsync(AccountDTO acc_dto)
        {
            await accountService.addAccountAsync(acc_dto);
        }
        public async Task updateAccountAsync(AccountDTO acc_dto)
        {
            await accountService.updateAccountAsync(acc_dto);
        }

        public async Task disableCutomerAsync(string cus_id)
        {
            var cus = await unitOfWork.Customers.GetByAsync(cus_id);
            if (cus != null) await unitOfWork.Customers.disable(cus);
        }
        public async Task activateCustomerAsync(string cus_id)
        {
            var cus = await unitOfWork.Customers.GetByAsync(cus_id);
            if (cus != null) await unitOfWork.Customers.activate(cus);
        }
    }
}