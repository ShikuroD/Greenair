using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using System;
namespace ApplicationCore.Services
{
    public class MakerService : Service<Maker, MakerDTO, MakerDTO>, IMakerService
    {
        public MakerService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {

        }
        //query
        public async Task<MakerDTO> getMakerAsync(string Maker_id)
        {
            return this.toDto(await unitOfWork.Makers.GetByAsync(Maker_id));
        }
        public async Task<IEnumerable<MakerDTO>> getAllMakerAsync()
        {
            return this.toDtoRange(await unitOfWork.Makers.GetAllAsync());
        }
        public async Task<IEnumerable<MakerDTO>> getMakerByNameAsync(string Maker_name)
        {
            return this.toDtoRange(await unitOfWork.Makers.getMakerByName(Maker_name));
        }
        //actions
        private async Task generateMakerId(Maker Maker)
        {
            var res = await unitOfWork.Makers.GetAllAsync();
            Maker.MakerId = String.Format("{0:000}", res.Count());
        }
        public async Task addMakerAsync(MakerDTO dto)
        {
            if (await unitOfWork.Makers.GetByAsync(dto.MakerId) == null)
            {
                var Maker = this.toEntity(dto);
                await this.generateMakerId(Maker);
                await unitOfWork.Makers.AddAsync(Maker);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task removeMakerAsync(string Maker_id)
        {
            var Maker = await unitOfWork.Makers.GetByAsync(Maker_id);
            if (Maker != null)
            {
                await unitOfWork.Makers.RemoveAsync(Maker);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task updateMakerAsync(MakerDTO dto)
        {
            if (await unitOfWork.Makers.GetByAsync(dto.MakerId) != null)
            {
                var Maker = this.toEntity(dto);
                await unitOfWork.Makers.UpdateAsync(Maker);
            }
            else
            {
                var Maker = this.toEntity(dto);
                await this.generateMakerId(Maker);
                await unitOfWork.Makers.AddAsync(Maker);
            }
            await unitOfWork.CompleteAsync();
        }
    }
}