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
    public class JobService : Service<Job, JobDTO, JobDTO>, IJobService
    {
        public JobService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {

        }
        //query
        public async Task<JobDTO> getJobAsync(string job_id)
        {
            return this.toDto(await unitOfWork.Jobs.GetByAsync(job_id));
        }
        public async Task<IEnumerable<JobDTO>> getAllJobAsync()
        {
            return this.toDtoRange(await unitOfWork.Jobs.GetAllAsync());
        }
        public async Task<IEnumerable<JobDTO>> getJobByNameAsync(string job_name)
        {
            return this.toDtoRange(await unitOfWork.Jobs.getJobByName(job_name));
        }
        //actions
        private async Task generateJobId(Job job)
        {
            var res = await unitOfWork.Jobs.GetAllAsync();
            job.JobId = String.Format("{0:000}", res.Count());
        }
        public async Task addJobAsync(JobDTO dto)
        {
            if (await unitOfWork.Jobs.GetByAsync(dto.JobId) == null)
            {
                var job = this.toEntity(dto);
                await this.generateJobId(job);
                await unitOfWork.Jobs.AddAsync(job);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task removeJobAsync(string job_id)
        {
            var job = await unitOfWork.Jobs.GetByAsync(job_id);
            if (job != null)
            {
                await unitOfWork.Jobs.RemoveAsync(job);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task updateJobAsync(JobDTO dto)
        {
            if (await unitOfWork.Jobs.GetByAsync(dto.JobId) != null)
            {
                var job = this.toEntity(dto);
                await unitOfWork.Jobs.UpdateAsync(job);
            }
            else
            {
                var job = this.toEntity(dto);
                await this.generateJobId(job);
                await unitOfWork.Jobs.AddAsync(job);
            }
            await unitOfWork.CompleteAsync();
        }
    }
}