using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using Newtonsoft.Json;
using Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using ApplicationCore.DTOs;
namespace Presentation.Pages.Admin
{
    public class EmployeeModel : PageModel
    {
        private readonly IUnitOfWork _unitofwork;

        public EmployeeModel(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IEnumerable<Employee> ListEmployees { get; set; }
        public IEnumerable<Job> ListJobs { get; set; }
        public async Task OnGet()
        {
            ListEmployees = await _unitofwork.Employees.GetAllAsync();
            ListJobs = await _unitofwork.Jobs.GetAllAsync();
        }
    }
}