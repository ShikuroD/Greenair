using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using Presentation.ViewModels;
namespace Presentation.Services.ServiceInterfaces
{
    public interface IRouteVMService
    {
        Task<RoutePageVM> GetRoutePageViewModelAsync(string searchString, int pageIndex = 1);
        Task<IEnumerable<AirportDTO>> GetAllAirport();
    }
}