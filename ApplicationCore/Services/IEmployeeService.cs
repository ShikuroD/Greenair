using System.Threading.Tasks;
using System;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using System.Collections.Generic;
namespace ApplicationCore.Services
{
    public interface IEmployeeService : IService<Employee, EmployeeDTO, EmployeeDTO>
    {
        //query
        Task<EmployeeDTO> getEmployeeAsync(string emp_id);
        Task<IEnumerable<EmployeeDTO>> getAllEmployeeAsync();
        //Task<IEnumerable<EmployeeDTO>> getEmployeeByJobAsync();
        Task<IEnumerable<EmployeeDTO>> getEmployeeByName(string lastname, string firstname);
        Task<IEnumerable<EmployeeDTO>> getEmployeeByName(string fullname);

        //actions

        Task addEmployeeAsync(EmployeeDTO dto);
        Task removeEmployeeAsync(string emp_id);
        Task updateEmployeeAsync(EmployeeDTO dto);


        Task disableCutomerAsync(string emp_id);
        Task activateEmployeeAsync(string emp_id);
    }
}