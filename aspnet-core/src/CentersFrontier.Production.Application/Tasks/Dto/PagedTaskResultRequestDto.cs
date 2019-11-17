using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Tasks.Dto
{
    public class PagedTaskResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}