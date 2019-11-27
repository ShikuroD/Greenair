using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.ViewModels;
namespace Presentation.Services.ServiceInterfaces
{
    public interface IAirportVMService
    {
        AirportPageVM GetAirportPageViewModel(string searchString, int pageIndex = 1);
    }
}