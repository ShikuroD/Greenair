using Presentation;
using ApplicationCore.DTOs;
namespace Presentation.ViewModels
{
    public class RoutePageVM
    {
        public PaginatedList<RouteDTO> Routes { get; set; }
    }
}