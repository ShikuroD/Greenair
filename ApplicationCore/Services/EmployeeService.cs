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
    public class EmployeeService : Service<Employee, EmployeeDTO, EmployeeDTO>, IEmployeeService
    {
        public IEnumerable<Employee> List { get; set; }
        public EmployeeService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {
            List = unitOfWork.Employees.GetAllAsync().GetAwaiter().GetResult();
        }
        //query
        public async Task<EmployeeDTO> getEmployeeAsync(string emp_id)
        {
            var emp = await unitOfWork.Employees.GetByAsync(emp_id);
            Console.WriteLine("qwerty {0}", emp.FullName);
            if (emp == null) return null;
            return toDto(emp);
        }
        public async Task<IEnumerable<EmployeeDTO>> getAllEmployeeAsync()
        {
            return toDtoRange(await unitOfWork.Employees.GetAllAsync());
        }


        public async Task<IEnumerable<EmployeeDTO>> getEmployeeByName(string lastname, string firstname)
        {
            return this.toDtoRange(await unitOfWork.Employees.getEmployeeByName(lastname, firstname));
        }
        public async Task<IEnumerable<EmployeeDTO>> getEmployeeByName(string fullname)
        {
            return this.toDtoRange(await unitOfWork.Employees.getEmployeeByName(fullname));
        }






        //actions
        public async Task orderTicketAsync(string flight_id, string emp_id, string assined_emp, string ticket_type_id)
        {
            var tickets = await unitOfWork.Flights.getAvailableTickets(flight_id);
            if (tickets.Count() >= 1)
            {
                var ticket = tickets.ElementAt(0);
                await unitOfWork.Flights.orderTicket(ticket, emp_id, assined_emp, ticket_type_id);
            }
        }
        public async Task orderTicketRangeAsync(string flight_id, int adult_num, int child_num, string emp_id)
        {
            int sum = adult_num + child_num;
            var tickets = await unitOfWork.Flights.getAvailableTickets(flight_id);
            if (tickets.Count() >= sum)
            {
                for (int i = 0; i < sum; i++)
                {
                    if (i < adult_num)
                    {
                        await unitOfWork.Flights.orderTicket(tickets.ElementAt(i), emp_id, null, "000");
                    }
                    else
                    {
                        await unitOfWork.Flights.orderTicket(tickets.ElementAt(i), emp_id, null, "001");
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

        private async Task generateEmployeeIDAsync(Employee emp)
        {
            if (String.IsNullOrEmpty(emp.Id))
            {
                var res = await unitOfWork.Employees.GetAllAsync();
                emp.Id = String.Format("{0:00000}", res.Count());
            }

        }
        public async Task addEmployeeAsync(EmployeeDTO dto)
        {
            if (await unitOfWork.Employees.GetByAsync(dto.Id) == null)
            {
                var emp = this.toEntity(dto);
                await this.generateEmployeeIDAsync(emp);
                await unitOfWork.Employees.AddAsync(emp);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task removeEmployeeAsync(string emp_id)
        {
            var emp = await unitOfWork.Employees.GetByAsync(emp_id);
            if (emp != null)
            {
                await unitOfWork.Employees.RemoveAsync(emp);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task updateEmployeeAsync(EmployeeDTO dto)
        {
            if (await unitOfWork.Employees.GetByAsync(dto.Id) != null)
            {
                var emp = this.toEntity(dto);
                await unitOfWork.Employees.UpdateAsync(emp);
            }
            else
            {
                var emp = this.toEntity(dto);
                await unitOfWork.Employees.UpdateAsync(emp);
            }
            await unitOfWork.CompleteAsync();
        }


        public async Task disableCutomerAsync(string emp_id)
        {
            var emp = await unitOfWork.Employees.GetByAsync(emp_id);
            if (emp != null) await unitOfWork.Employees.disable(emp);
        }
        public async Task activateEmployeeAsync(string emp_id)
        {
            var emp = await unitOfWork.Employees.GetByAsync(emp_id);
            if (emp != null) await unitOfWork.Employees.activate(emp);
        }
    }
}