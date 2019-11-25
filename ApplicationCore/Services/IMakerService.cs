using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;
namespace ApplicationCore.Services
{
    public interface IMakerService : IService<Maker, MakerDTO, MakerDTO>
    {
        //query
        Task<MakerDTO> getMakerAsync(string maker_id);
        Task<IEnumerable<MakerDTO>> getAllMakerAsync();
        Task<IEnumerable<MakerDTO>> getMakerByNameAsync(string maker_name);

        //actions
        Task addMakerAsync(MakerDTO dto);
        Task removeMakerAsync(string Maker_id);
        Task updateMakerAsync(MakerDTO dto);
    }
}