
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
namespace ApplicationCore.Services
{
    public class AccountService : Service<Account, AccountDTO, AccountDTO>, IAccountService
    {
        public AccountService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {

        }

        //query
        public async Task<IEnumerable<AccountDTO>> getAllAccount()
        {
            return this.toDtoRange(await unitOfWork.Accounts.GetAllAsync());
        }
        public async Task<AccountDTO> getAccount(string person_id)
        {
            var acc = await unitOfWork.Accounts.getAccountByPersonId(person_id);
            if (acc == null) return null;
            return this.toDto(acc);
        }


        //action
        public async Task addAccount(AccountDTO dto)
        {
            if (await unitOfWork.Accounts.GetByAsync(dto.Username) != null)
            {
                var acc = this.toEntity(dto);
                await unitOfWork.Accounts.AddAsync(acc);
                await unitOfWork.CompleteAsync();
            }


        }
        public async Task removeAccount(string person_id){

        }
        public async Task updateAccount(AccountDTO dto);

        public async Task<bool> isExistedUsername(string username);
        public async Task<bool> loginCheck(AccountDTO dto);

        public async Task disableAccount(string person_id);
        public async Task activateAccount(string person_id);

    }
}