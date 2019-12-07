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
    public class TicketTypeService : Service<TicketType, TicketTypeDTO, TicketTypeDTO>, ITicketTypeService
    {
        public IEnumerable<TicketType> List { get; set; }
        public TicketTypeService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {
            List = unitOfWork.TicketTypes.GetAllAsync().GetAwaiter().GetResult();
        }
        //query
        public async Task<TicketTypeDTO> getTicketTypeAsync(string ticket_type_id)
        {
            return this.toDto(await unitOfWork.TicketTypes.GetByAsync(ticket_type_id));
        }
        public async Task<IEnumerable<TicketTypeDTO>> getAllTicketTypeAsync()
        {
            return this.toDtoRange(await unitOfWork.TicketTypes.GetAllAsync());
        }


        //actions
        private async Task generateTicketTypeId(TicketType TicketType)
        {
            var res = await unitOfWork.TicketTypes.GetAllAsync();
            var id = res.LastOrDefault().TicketTypeId;
            var code = 0;
            Int32.TryParse(id, out code);
            TicketType.TicketTypeId = String.Format("{0:000}", code);
        }
        public async Task addTicketTypeAsync(TicketTypeDTO dto)
        {
            if (await unitOfWork.TicketTypes.GetByAsync(dto.TicketTypeId) == null)
            {
                var ticket_type = this.toEntity(dto);
                await this.generateTicketTypeId(ticket_type);
                await unitOfWork.TicketTypes.AddAsync(ticket_type);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task removeTicketTypeAsync(string ticket_type_id)
        {
            var ticket_type = await unitOfWork.TicketTypes.GetByAsync(ticket_type_id);
            if (ticket_type != null)
            {
                await unitOfWork.TicketTypes.RemoveAsync(ticket_type);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task updateTicketTypeAsync(TicketTypeDTO dto)
        {
            if (await unitOfWork.TicketTypes.GetByAsync(dto.TicketTypeId) != null)
            {
                var ticket_type = this.toEntity(dto);
                await unitOfWork.TicketTypes.UpdateAsync(ticket_type);
            }
            else
            {
                var ticket_type = this.toEntity(dto);
                await this.generateTicketTypeId(ticket_type);
                await unitOfWork.TicketTypes.AddAsync(ticket_type);
            }
            await unitOfWork.CompleteAsync();
        }
    }
}