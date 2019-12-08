
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using LinqKit;
namespace ApplicationCore.Services
{
    public class AccountService : Service<Account, AccountDTO, AccountDTO>, IAccountService
    {
        //public IEnumerable<Account> List { get; set; }
        public AccountService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {
            //List = unitOfWork.Accounts.GetAllAsync().GetAwaiter().GetResult();
        }

        //query
        public async Task<IEnumerable<AccountDTO>> getAllAccountAsync()
        {
            return this.toDtoRange(await unitOfWork.Accounts.GetAllAsync());
        }
        public async Task<AccountDTO> getAccountByPersonIdAsync(string person_id)
        {
            var acc = await unitOfWork.Accounts.getAccountByPersonId(person_id);
            if (acc == null) return null;
            return this.toDto(acc);
        }

        public async Task<AccountDTO> getAccountAsync(string username)
        {
            var acc = await unitOfWork.Accounts.GetByAsync(username);
            if (acc == null) return null;
            return this.toDto(acc);
        }


        //action
        public async Task addAccountAsync(AccountDTO dto)
        {
            var temp = await unitOfWork.Accounts.getAccountByPersonId(dto.PersonId);
            if (!await this.isExistedUsernameAsync(dto.Username) && temp == null)
            {
                var acc = this.toEntity(dto);
                await unitOfWork.Accounts.AddAsync(acc);
                await unitOfWork.CompleteAsync();
            }

        }
        public async Task removeAccountAsync(string person_id)
        {
            var acc = await unitOfWork.Accounts.getAccountByPersonId(person_id);
            if (acc != null)
            {
                await unitOfWork.Accounts.RemoveAsync(acc);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task updateAccountAsync(AccountDTO dto)
        {
            if (await this.isExistedUsernameAsync(dto.Username))
            {
                // var acc = this.toEntity(dto);
                // await unitOfWork.Accounts.UpdateAsync(acc);
                var acc = await unitOfWork.Accounts.GetByAsync(dto.Username);
                this.convertDtoToEntity(dto, acc);
            }
            else
            {
                var acc = this.toEntity(dto);
                await unitOfWork.Accounts.AddAsync(acc);
            }
            await unitOfWork.CompleteAsync();
        }
        public async Task<bool> isExistedUsernameAsync(string username)
        {
            return await unitOfWork.Accounts.GetByAsync(username) != null;
        }
        public async Task<bool> loginCheckAsync(AccountDTO dto)
        {
            var predicate = PredicateBuilder.New<Account>();
            predicate = predicate.And(m => m.Username.Equals(dto.Username));
            predicate = predicate.And(m => m.Password.Equals(dto.Password));
            var res = await unitOfWork.Accounts.FindAsync(predicate);
            if (res.Count() != 1) return false;
            return true;
        }
        public async Task<Person> getPersonByAccount(string username)
        {
            var acc = await unitOfWork.Accounts.GetByAsync(username);
            return await unitOfWork.Persons.GetByAsync(acc.PersonId);
        }

        public async Task disableAccountAsync(string person_id)
        {
            var acc = await unitOfWork.Accounts.getAccountByPersonId(person_id);
            if (acc != null)
            {
                await unitOfWork.Accounts.disable(acc);
                //await unitOfWork.CompleteAsync(); already in above function
            }
        }
        public async Task activateAccountAsync(string person_id)
        {
            var acc = await unitOfWork.Accounts.getAccountByPersonId(person_id);
            if (acc != null)
            {
                await unitOfWork.Accounts.activate(acc);
                //await unitOfWork.CompleteAsync(); already in above function
            }
        }

    }
}