using System.ComponentModel;
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
        // public IEnumerable<Maker> List { get; set; }
        public MakerService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {
            // List = unitOfWork.Makers.GetAllAsync().GetAwaiter().GetResult();
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
            var id = res.LastOrDefault().MakerId;
            var code = 0;
            Int32.TryParse(id, out code);
            Maker.MakerId = String.Format("{0:000}", code);
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
                // var Maker = this.toEntity(dto);
                // await unitOfWork.Makers.UpdateAsync(Maker);
                var Maker = await unitOfWork.Makers.GetByAsync(dto.MakerId);
                this.convertDtoToEntity(dto, Maker);
            }
            else
            {
                var Maker = this.toEntity(dto);
                await this.generateMakerId(Maker);
                await unitOfWork.Makers.AddAsync(Maker);
            }
            await unitOfWork.CompleteAsync();
        }

        public async Task disableMakerAsync(string cus_id)
        {
            var cus = await unitOfWork.Makers.GetByAsync(cus_id);
            if (cus != null) await unitOfWork.Makers.disable(cus);
        }
        public async Task activateMakerAsync(string cus_id)
        {
            var cus = await unitOfWork.Makers.GetByAsync(cus_id);
            if (cus != null) await unitOfWork.Makers.activate(cus);
        }
    }
}