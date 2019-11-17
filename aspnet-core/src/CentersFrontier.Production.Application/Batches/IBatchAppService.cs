using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using CentersFrontier.Production.Batches.Dto;
using CentersFrontier.Production.Tasks;

namespace CentersFrontier.Production.Batches
{
    public interface IBatchAppService : IAsyncCrudAppService<BatchDto, long, PagedBatchResultRequestDto, CreateBatchDto, BatchDto>
    {
        Task ActivateBatch(long id);
        Task DeactivateBatch(long id);
    }

    public class BatchAppService : AsyncCrudAppService<ManufacturingBatch, BatchDto, long, PagedBatchResultRequestDto, CreateBatchDto, BatchDto>
    {
        public BatchAppService(IRepository<ManufacturingBatch, long> repository) : base(repository)
        {
        }
    }
}