using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Collections.Generic;
using AutoMapper;
using System;
using ApplicationCore.Interfaces;
namespace ApplicationCore.Services
{
    public class Service<Entity, Dto, SaveDto> : IService<Entity, Dto, SaveDto>
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;
        public Service(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }


        public Dto toDto(Entity entity)
        {
            return mapper.Map<Entity, Dto>(entity);
        }

        public IEnumerable<Dto> toDtoRange(IEnumerable<Entity> entities)
        {
            return mapper.Map<IEnumerable<Entity>, IEnumerable<Dto>>(entities);
        }

        public Entity toEntity(SaveDto save)
        {
            return mapper.Map<SaveDto, Entity>(save);
        }
        public void convertEntityToDto(Entity entity, Dto dto)
        {
            mapper.Map<Entity, Dto>(entity, dto);
        }
        public void convertDtoToEntity(SaveDto save, Entity entity)
        {
            mapper.Map<SaveDto, Entity>(save, entity);
        }

        public async Task<int> CompleteAsync()
        {
            return await unitOfWork.CompleteAsync();
        }
    }
}