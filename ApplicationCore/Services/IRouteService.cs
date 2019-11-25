using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
namespace ApplicationCore.Services
{
    public interface IRouteService : IService<Route, RouteDTO, RouteDTO>
    {
        //query
        Task<RouteDTO> getRouteAsync(string route_id);
        Task<IEnumerable<RouteDTO>> getAllRouteAsync();
        Task<IEnumerable<RouteDTO>> getRouteByOriginAsync(string origin);
        Task<IEnumerable<RouteDTO>> getRouteByDestinationAsync(string destination);
        //actions
        Task addRouteAsync(RouteDTO dto);
        Task removeRouteAsync(string route_id);
        Task updateRouteAsync(RouteDTO dto);
    }
}