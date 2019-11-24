using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IMakerRepository : IRepository<Maker>
    {
        Task<IEnumerable<Maker>> getMakerByName(string name);
    }
}