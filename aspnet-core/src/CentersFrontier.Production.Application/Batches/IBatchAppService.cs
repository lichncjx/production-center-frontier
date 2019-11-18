using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using CentersFrontier.Production.Batches.Dto;
using CentersFrontier.Production.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CentersFrontier.Production.Batches
{
    public interface IBatchAppService : IAsyncCrudAppService<BatchDto, long, PagedBatchResultRequestDto, CreateBatchDto, BatchDto>
    {
        Task ActivateBatch(long id);
        Task DeactivateBatch(long id);
        Task ToggleActivationStatus(long id);
        Task NewSideTask(NewSideTaskInput input);
        Task PrepareForTransfer(PrepareForTransferInput input);
    }

    public class BatchAppService : AsyncCrudAppService<ManufacturingBatch, BatchDto, long, PagedBatchResultRequestDto, CreateBatchDto, BatchDto>, IBatchAppService
    {
        public BatchAppService(IRepository<ManufacturingBatch, long> repository) : base(repository)
        {
        }

        public async Task ActivateBatch(long id)
        {
            var batch = await Repository.GetAsync(id);
            if (batch.IsActive)
                throw new UserFriendlyException("条码已处于激活状态");
            batch.IsActive = true;
        }

        public async Task DeactivateBatch(long id)
        {
            var batch = await Repository.GetAsync(id);
            if (!batch.IsActive)
                throw new UserFriendlyException("条码已处于未激活状态");
            batch.IsActive = true;
        }

        public async Task ToggleActivationStatus(long id)
        {
            var batch = await Repository.GetAsync(id);
            batch.IsActive = !batch.IsActive;
        }

        public async Task NewSideTask(NewSideTaskInput input)
        {
            var batch = await Repository.GetAllIncluding(b => b.SideTasks).SingleAsync(b => b.Id == input.Id);
            batch.NewSideTask(input.DrawingCode, input.DrawingName, input.Quantity, input.ManufacturingId);;
        }
    }
}