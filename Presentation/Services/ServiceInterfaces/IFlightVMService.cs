using System;
using System.Threading.Tasks;
using Presentation.ViewModels;
namespace Presentation.Services.ServiceInterfaces
{
    public interface IFlightVMService
    {  
        FlightVM GetFlightListVm(string origin_id, string destination_id, DateTime dep_date, DateTime arr_date,int adults_num, int childs_num);
    }
}