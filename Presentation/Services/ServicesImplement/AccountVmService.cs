using Presentation.Services.ServiceInterfaces;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using Presentation.ViewModels;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.Persistence.Services;
using AutoMapper;
using System;

namespace Presentation.Services.ServicesImplement
{
    public class AccountVmService : IAccountVmService
    {
        private readonly IAccountService _service;
        public AirportVMService(IAccountService accounttService)
        {
            _service = accountService;
        }
    }
}