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
        // public IEnumerable<Job> List { get; set; }
        public JobService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {
            // List = unitOfWork.Jobs.GetAllAsync().GetAwaiter().GetResult();
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
        private async Task generateJobId(Job Job)
        {
            var res = await unitOfWork.Jobs.GetAllAsync();
            var id = res.LastOrDefault().JobId;
            var code = 0;
            Int32.TryParse(id, out code);
            Job.JobId = String.Format("{0:000}", code);
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

        public async Task disableJobAsync(string cus_id)
        {
            var cus = await unitOfWork.Jobs.GetByAsync(cus_id);
            if (cus != null) await unitOfWork.Jobs.disable(cus);
        }
        public async Task activateJobAsync(string cus_id)
        {
            var cus = await unitOfWork.Jobs.GetByAsync(cus_id);
            if (cus != null) await unitOfWork.Jobs.activate(cus);
        }
    }
}