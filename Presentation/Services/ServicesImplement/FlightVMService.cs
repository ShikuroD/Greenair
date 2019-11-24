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
    public class FlightVMService : IFlightVMService
    {
        private readonly IFlightService _service;
        public FlightVMService(IFlightService flightService)
        {
            _service = flightService;
        }
        public FlightVM GetFlightListVm(string origin_id, string destination_id, DateTime dep_date, DateTime arr_date,int adults_num, int childs_num)
        {
            var FlightSearch = _service.searchFlightAsync(origin_id,destination_id,dep_date,arr_date,adults_num,childs_num);
            return new FlightVM();
        }
    }
}