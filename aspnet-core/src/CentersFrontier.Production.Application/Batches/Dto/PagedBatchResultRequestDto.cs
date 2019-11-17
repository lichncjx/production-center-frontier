using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Batches.Dto
{
    public class PagedBatchResultRequestDto : PagedResultRequestDto
    {
        public bool IsActive { get; set; }
    }
}