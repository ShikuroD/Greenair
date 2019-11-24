using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Threading.Tasks;
using ApplicationCore;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repos
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public AccountRepository(GreenairContext context) : base(context)
        {

        }

        private async Task changeAccountStatus(string username, STATUS status)
        {
            try
            {
                var acc = await this.GetByAsync(username);
                acc.Status = status;
                this.Context.Update(acc);
                await this.Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("ChangeAccountStatus() Unexpected: " + e);
            }
        }

        public async Task activate(string username)
        {
            await this.changeAccountStatus(username, STATUS.AVAILABLE);
        }

        public async Task disable(string username)
        {
            await this.changeAccountStatus(username, STATUS.DISABLED);
        }
    }
}