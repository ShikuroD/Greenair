using System.Threading.Tasks;
using Presentation.ViewModels;
namespace Presentation.Services.ServiceInterfaces
{
    public interface IRouteVMService
    {
        Task<RoutePageVM> GetRoutePageViewModelAsync(string searchString, int pageIndex = 1);
    }
}