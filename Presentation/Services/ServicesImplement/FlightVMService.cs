using Presentation.Services.ServiceInterfaces;
using System.Collections.Generic;
using System.Collections;
using ApplicationCore.Interfaces;
using Presentation.ViewModels;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.Services;
using AutoMapper;
using System;

namespace Presentation.Services.ServicesImplement
{
    public class FlightVMService
    // : IFlightVMService
    {
        private readonly IFlightService _service;
        public FlightVMService(IFlightService flightService)
        {
            _service = flightService;
        }
<<<<<<< HEAD
=======
        // public async Task<IEnumerable<FlightDTO>> GetFlightListVm(string origin_id, string destination_id, DateTime dep_date, DateTime arr_date, int adults_num, int childs_num)
        // {
        //     var FlightSearch = await _service.searchFlightAsync(origin_id, destination_id, dep_date, arr_date, adults_num, childs_num);
        //     return FlightSearch;
        //     return null;
        // }
>>>>>>> e2146077ab28a5eb97d12a689549a17462d6f9d5
        // public async Task<IEnumerable<FlightDTO>> GetFlightListVm(string origin_id, string destination_id, DateTime dep_date, DateTime arr_date, int adults_num, int childs_num)
        // {
        //     var FlightSearch = await _service.searchFlightAsync(origin_id, destination_id, dep_date, arr_date, adults_num, childs_num);
        //     return FlightSearch;
        // }
<<<<<<< HEAD
=======
        public async Task<IEnumerable<FlightDTO>> GetFlightListVm(string origin_id, string destination_id, DateTime dep_date, DateTime arr_date, int adults_num, int childs_num)
        {
            var FlightSearch = await _service.searchFlightAsync(origin_id, destination_id, dep_date, adults_num, childs_num);
            return FlightSearch;
        }

>>>>>>> e2146077ab28a5eb97d12a689549a17462d6f9d5
    }
}