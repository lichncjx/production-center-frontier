using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

