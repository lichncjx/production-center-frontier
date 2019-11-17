using System.Threading.Tasks;
using Abp.Application.Services;
using CentersFrontier.Production.Batches.Dto;

namespace CentersFrontier.Production.Batches
{
    public interface IBatchAppService : IAsyncCrudAppService<BatchDto, long, PagedBatchResultRequestDto, CreateBatchDto, BatchDto>
    {
        Task ActivateTask(long id);
        Task DeactivateTask(long id);
    }
}