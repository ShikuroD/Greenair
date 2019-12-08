using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IMakerRepository : IRepository<Maker>
    {
        Task<IEnumerable<Maker>> getMakerByName(string name);

        Task disable(string Maker_id);
        Task activate(string Maker_id);
        Task disable(Maker acc);
        Task activate(Maker acc);
    }
}