using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;
namespace Infrastructure.Persistence.Services
{
    public interface IAccountService : IService<Account, AccountDTO, AccountDTO>
    {
        //query
        Task<IEnumerable<AccountDTO>> getAllAccount();
        Task<AccountDTO> getAccount(string person_id);


        //action
        Task addAccount(AccountDTO dto);
        Task removeAccount(string person_id);
        Task updateAccount(AccountDTO dto);

        Task<bool> isExistedUsername(string username);
        Task<bool> loginCheck(AccountDTO dto);

        Task disableAccount(string person_id);
        Task activateAccount(string person_id);

    }
}